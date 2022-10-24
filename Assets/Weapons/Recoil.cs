using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    private Vector3 CurrentRotation;
    private Vector3 TargetRotation;

    [SerializeField] private float RecoilX;
    [SerializeField] private float RecoilY;
    [SerializeField] private float RecoilZ;

    [SerializeField] private float Snappiness;
    [SerializeField] private float ReturnSpeed;
    

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RecoilFire();
        }

        TargetRotation = Vector3.Lerp(TargetRotation, Vector3.zero, ReturnSpeed * Time.deltaTime);
        CurrentRotation = Vector3.Slerp(CurrentRotation, TargetRotation, Snappiness * Time.fixedDeltaTime);

        transform.localRotation = Quaternion.Euler(CurrentRotation);
    }

    public void RecoilFire()
    {
        TargetRotation += new Vector3(RecoilX, Random.Range(-RecoilY, RecoilY), Random.Range(-RecoilZ, RecoilZ));
    }
}
