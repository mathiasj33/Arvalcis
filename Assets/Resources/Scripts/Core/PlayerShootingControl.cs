using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingControl : MonoBehaviour
{
    public GameObject line;
    public GameObject shot;

    public bool Aiming { get; private set; }

    private PlayerAnimationControl animControl;
    private Invoker invoker;

    void Start()
    {
        invoker = GameObject.Find("Main").GetComponent<Invoker>();
        animControl = GetComponent<PlayerAnimationControl>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Aiming)
        {
            Aiming = true;
            animControl.StartAiming();
            invoker.Invoke(.25f, () => line.SetActive(true));
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && Aiming)
        {
            Aiming = false;
            animControl.StopAiming();
            line.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && Aiming)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        animControl.Shoot();
        line.SetActive(false);
        invoker.Invoke(.6f, () => line.SetActive(true));

        GameObject newShot = Instantiate(shot, shot.transform.parent);
        newShot.transform.parent = null;
        RaycastHit hit;
        Ray ray = new Ray(shot.transform.position, shot.transform.forward);
        bool hitSuccess = Physics.Raycast(ray, out hit, 9);
        SetUpShotVisuals(newShot, hitSuccess, hitSuccess ? hit.point : Vector3.zero);

        newShot.SetActive(true);
        newShot.AddComponent<FadeLineOutControl>();
    }

    private void SetUpShotVisuals(GameObject shot, bool hitSuccess, Vector3 hitPoint)
    {
        var lineRenderer = shot.GetComponent<LineRenderer>();
        if (hitSuccess)
        {
            shot.transform.Find("EnemyLight").position = hitPoint;
            float dist = (hitPoint - shot.transform.position).magnitude;
            lineRenderer.SetPosition(1, new Vector3(0, 0, dist * 9));
        }
        else
        {
            shot.transform.Find("EnemyLight").gameObject.SetActive(false);
            lineRenderer.SetPosition(1, new Vector3(0, 0, 80));
            Color c = lineRenderer.endColor;
            lineRenderer.endColor = new Color(c.r, c.g, c.b, 0);
        }
    }
}
