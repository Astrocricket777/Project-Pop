using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecks : MonoBehaviour
{
    public Animator TheAnimator;

    void Update()
    {
        WalkCheck();
        AimCheck();
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
       }
       else
       {
            TheAnimator.SetBool("IsAiming", false);
       }
    }
}
