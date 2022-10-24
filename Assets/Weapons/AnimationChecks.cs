using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecks : MonoBehaviour
{
    public Animator TheAnimator;

    public PlayerMovement Move;
    public GunSystem Gun;

    public Camera Cam;

    void Update()
    {
        WalkCheck();
        AimCheck();
        SprintCheck();

        if (Gun.BulletsLeft > 0)
        {
            ShootCheck();
        }
    }

    void WalkCheck()
    {
        if (Input.GetKey(KeyCode.W))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TheAnimator.SetBool("IsWalking", true);
        }
        else
        {
            TheAnimator.SetBool("IsWalking", false);
        }
    }

    void AimCheck()
    {
       if (Input.GetMouseButton(1)) 
       {
            TheAnimator.SetBool("IsAiming", true);

            Cam.fieldOfView = 55f;
       }
       else
       {
            TheAnimator.SetBool("IsAiming", false);

            Cam.fieldOfView = 70f;
       }
    }

    void ShootCheck()
    {
        if (Gun.AllowButtonHold == true)
        {
            if (Input.GetMouseButton(0))
            {
                TheAnimator.SetBool("IsFiring", true);
            }
            else
            {
                TheAnimator.SetBool("IsFiring", false);
            }
            
        }
        else if (Gun.AllowButtonHold == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TheAnimator.SetBool("IsFiring", true);
            }
            else
            {
                TheAnimator.SetBool("IsFiring", false);
            }
        }
        else
        {
            TheAnimator.SetBool("IsFiring", false);
        }
    }

    void SprintCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TheAnimator.SetBool("IsSprinting", true);

            Move.maxSpeed = 7f;
        }
        else
        {
            TheAnimator.SetBool("IsSprinting", false);

            Move.maxSpeed = 5f;
        }
    }
}
