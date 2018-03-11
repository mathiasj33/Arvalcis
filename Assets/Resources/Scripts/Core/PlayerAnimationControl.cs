using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

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
