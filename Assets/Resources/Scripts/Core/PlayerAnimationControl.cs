using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{

    private Animator animator;
    private float time = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > .5f)
        {
            time = 0;
            //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"));
        }
    }

    public void StartWalking()
    {
        animator.SetBool("Walking", true);
    }

    public void StopWalking()
    {
        animator.SetBool("Walking", false);
    }

    public void StartAiming()
    {
        animator.SetBool("Aiming", true);
    }

    public void StopAiming()
    {
        animator.SetBool("Aiming", false);
    }

    public void Shoot()
    {
        animator.SetTrigger("Shoot");
    }
}
