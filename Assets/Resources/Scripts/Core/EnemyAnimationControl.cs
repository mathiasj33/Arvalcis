using UnityEngine;
using System.Collections;

public class EnemyAnimationControl : MonoBehaviour {

    public GameObject chest;
    public GameObject tipPosition;

    private Animator animator;
    private CharacterController characterController;
    private Camera cam;
    private ParticleSystem blood;
    private GameObject player;
    private Invoker invoker;

    private bool turnToPlayer;

    void Start () {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        blood = GameObject.Find("Blood").GetComponent<ParticleSystem>();
        player = GameObject.Find("Player");
        invoker = GameObject.Find("Main").GetComponent<Invoker>();
    }

    void Update()
    {
        if(turnToPlayer)
        {
            Vector3 playerSameLevel = player.transform.position;
            playerSameLevel.y = transform.position.y;
            Vector3 dir = playerSameLevel - transform.position;
            dir.Normalize();
            Quaternion goalRot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, goalRot, Time.deltaTime * 4);
        }
    }

    public void Walk()
    {
        animator.SetBool("Walking", true);
    }

    public void Shoot()
    {
        turnToPlayer = true;
        animator.SetTrigger("Shoot");
        invoker.Invoke(.3f, CreateLaser);
    }

    public void PlayDeathAnim()
    {
        Destroy(characterController);
        animator.enabled = false;
        blood.transform.position = GameObject.Find("BloodPos").transform.position;
        blood.transform.rotation = GameObject.Find("BloodPos").transform.rotation;
        blood.Play();
        foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
        {
            r.isKinematic = false;
        }
        chest.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 100, ForceMode.Impulse);
        Destroy(this);
    }

    private void CreateLaser()
    {
        GameObject empty = new GameObject();
        empty.AddComponent<LineRenderer>();
        LineRenderer laser = empty.GetComponent<LineRenderer>();

        laser.sharedMaterial = (Material)Resources.Load("Models/laser");
        laser.SetColors(new Color(255, 0, 0, 1), new Color(255, 0, 0, 1));
        laser.SetWidth(0.1f, 0.1f);
        laser.SetPosition(0, tipPosition.transform.position);
        laser.SetPosition(1, player.transform.position);
    }
}
