using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecks : MonoBehaviour
{
    public Animator TheAnimator;
    public ParticleSystem MuzzleFlash;

    public Camera Cam;

    void Update()
    {
        WalkCheck();
        AimCheck();
        ShootCheck();
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
        if (Input.GetMouseButton(0))
        {
            TheAnimator.SetBool("IsFiring", true);
            MuzzleFlash.Play();
        }
        else
        {
            TheAnimator.SetBool("IsFiring", false);
        }
    }
}
