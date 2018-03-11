using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{

    public float speed = 1;
    public float rotateSpeed = 1;

    private PlayerAnimationControl animControl;
    private PlayerShootingControl shootingControl;
    private CharacterController characterController;

    private bool walking;

    void Start()
    {
        animControl = GetComponent<PlayerAnimationControl>();
        shootingControl = GetComponent<PlayerShootingControl>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        if (shootingControl.Aiming)
        {
            Vector3 hit = GetMouseRayHit();
            Vector3 lookDir = (hit - transform.position).normalized;
            lookDir.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * rotateSpeed * 5);
        }
        else
        {
            Vector3 movement = GetVectorFromInput();
            Vector3 lookDir = GetVectorFromInput();
            if (movement == Vector3.zero) return;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDir), Time.deltaTime * rotateSpeed);
        }
    }

    private Vector3 GetMouseRayHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit)) throw new InvalidOperationException("There is no object under the user's mouse");
        return hit.point;
    }

    private void Move()
    {
        Vector3 movement = GetVectorFromInput();
        if (movement == Vector3.zero)
        {
            if (walking)
            {
                walking = false;
                animControl.StopWalking();
            }
        }
        else
        {
            if (!walking)
            {
                walking = true;
                animControl.StartWalking();
            }
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            movement.y = -9.81f * Time.deltaTime / 20; ;
            characterController.Move(movement);
        }
    }

    private Vector3 GetVectorFromInput()
    {
        Vector3 vec = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) vec += Vector3.forward;
        if (Input.GetKey(KeyCode.A)) vec += Vector3.left;
        if (Input.GetKey(KeyCode.S)) vec += Vector3.back;
        if (Input.GetKey(KeyCode.D)) vec += Vector3.right;
        return vec;
    }
}
