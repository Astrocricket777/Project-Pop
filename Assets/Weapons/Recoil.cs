using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public AnimationChecks AimCheck;
    public GunSystem Gun;

    bool IsAiming;

    private Vector3 CurrentRotation;
    private Vector3 TargetRotation;

    
    

    
    void Update()
    {

        IsAiming = AimCheck.IsAiming;

        TargetRotation = Vector3.Lerp(TargetRotation, Vector3.zero, Gun.ReturnSpeed * Time.deltaTime);
        CurrentRotation = Vector3.Slerp(CurrentRotation, TargetRotation, Gun.Snappiness * Time.fixedDeltaTime);

        transform.localRotation = Quaternion.Euler(CurrentRotation);
    }

    public void RecoilFire()
    {
        if (IsAiming)
        {
            TargetRotation += new Vector3(Gun.AimRecoilX, Random.Range(-Gun.AimRecoilY, Gun.AimRecoilY), Random.Range(-Gun.AimRecoilZ, Gun.AimRecoilZ));
        }
        else
        {
            TargetRotation += new Vector3(Gun.RecoilX, Random.Range(-Gun.RecoilY, Gun.RecoilY), Random.Range(-Gun.RecoilZ, Gun.RecoilZ));
        }
    }
}
