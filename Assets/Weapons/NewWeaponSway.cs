using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeaponSway : MonoBehaviour
{
    [Header("Sway Options")]
    public float Smooth;
    public float SwayMultiplier;

    private void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * SwayMultiplier;
        float MouseY = Input.GetAxisRaw("Mouse Y") * SwayMultiplier;

        if (Input.GetMouseButton(1)) 
       {
            Smooth = 2f;
            SwayMultiplier = 1f;
       }
       else
       {
            Smooth = 6f;
            SwayMultiplier = 3f;
       }

        Quaternion RotationX = Quaternion.AngleAxis(-MouseY, Vector3.right);
        Quaternion RotationY = Quaternion.AngleAxis(MouseX, Vector3.up);

        Quaternion TargetRotation = RotationX * RotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRotation, Smooth * Time.deltaTime);
    }
}
