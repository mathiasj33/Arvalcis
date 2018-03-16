using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour {

    public GameObject blade;

    private Animator playerAnimator;
    private Animator bladeAnimator;

    private Invoker invoker;

    void Start() {
        playerAnimator = GetComponent<Animator>();
        bladeAnimator = blade.GetComponent<Animator>();
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

    public void Takeout() {
        playerAnimator.SetTrigger("Takeout");
        invoker.Invoke(.1f, () => bladeAnimator.SetTrigger("Slide"));
    }
}