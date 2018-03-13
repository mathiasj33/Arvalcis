using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControl : MonoBehaviour
{
    public GameObject chest;
    public GameObject blood;

    private CharacterController characterController;
    private Animator animator;

    private Invoker invoker;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        invoker = GameObject.Find("Main").GetComponent<Invoker>();
    }

    void Update()
    {

    }

    public void PlayDeathAnim(Vector3 dir)
    {
        ActivateRagdoll();
        chest.GetComponent<Rigidbody>().AddForce(dir * 100, ForceMode.Impulse);
        invoker.Invoke(1f, ShowBlood);
        GameObject copy = gameObject; //This is necessary because the script gets destroyed before the invoker executes
        invoker.Invoke(1f, () => copy.AddComponent<TurnEyesOffControl>());
        Destroy(this);
    }

    private void ActivateRagdoll()
    {
        Destroy(characterController);
        Destroy(GetComponent<BoxCollider>()); //This collider is only used to provide a better hitbox
        animator.enabled = false;
        foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
        {
            r.isKinematic = false;
        }
    }

    private void ShowBlood()
    {
        blood.transform.parent = null;
        blood.transform.position = new Vector3(blood.transform.position.x, .05f, blood.transform.position.z);
        blood.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        blood.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", LoadRandomBloodTexture());
        blood.AddComponent<ScaleBloodControl>();
        blood.SetActive(true);
    }

    private Texture LoadRandomBloodTexture()
    {
        int texID = Random.Range(1, 3);
        return Resources.Load<Texture>("Textures/BloodSplats/Splat" + texID);
    }
}
