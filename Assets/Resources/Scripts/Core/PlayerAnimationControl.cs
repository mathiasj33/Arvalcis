using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour {

    private Animator playerAnimator;

    private Invoker invoker;

    void Start() {
        playerAnimator = GetComponent<Animator>();
        invoker = GameObject.Find("Main").GetComponent<Invoker>();
    }

    void Update() { }

    public void StartWalking() {
        playerAnimator.SetBool("Walking", true);
    }

    public void StopWalking() {
        playerAnimator.SetBool("Walking", false);
    }

    public void StartAiming() {
        playerAnimator.SetBool("Aiming", true);
    }

    public void StopAiming() {
        playerAnimator.SetBool("Aiming", false);
    }

    public void Shoot() {
        playerAnimator.SetTrigger("Shoot");
    }
}