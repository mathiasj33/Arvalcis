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
        Destroy(characterController);
        Destroy(GetComponent<BoxCollider>()); //this collider is only used to provide a better hitbox
        animator.enabled = false;
        // blood.transform.position = GameObject.Find("BloodPos").transform.position;
        // blood.transform.rotation = GameObject.Find("BloodPos").transform.rotation;
        // blood.Play();
        foreach (Rigidbody r in GetComponentsInChildren<Rigidbody>())
        {
            r.isKinematic = false;
        }
        chest.GetComponent<Rigidbody>().AddForce(dir * 100, ForceMode.Impulse);
		invoker.Invoke(1f, ShowBlood);
        //Destroy(this);
    }

    private void ShowBlood()
    {
		blood.transform.parent = null;
		blood.transform.position = new Vector3(blood.transform.position.x, .05f, blood.transform.position.z);
        blood.transform.rotation = Quaternion.Euler(0, 0, 0);
        blood.AddComponent<ScaleBloodControl>();
        blood.SetActive(true);
    }
}
