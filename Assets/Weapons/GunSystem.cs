using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public int Damage;
    public float TimeBetweenShooting, Spread, Range, ReloadTime, TimeBetweenShots;
    public int MagazineSize, BulletsPerTap;
    public bool AllowButtonHold;
    public int BulletsLeft, BulletsShot;

    bool Shooting, ReadyToShoot, Reloading;

    public Camera Cam;
    public RaycastHit Hit;
    public LayerMask WhatIsEnemy;

    public ParticleSystem MuzzleFlash;
    public GameObject BulletHole;

    private void Awake()
    {
        BulletsLeft = MagazineSize;
        ReadyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (AllowButtonHold)
        {
            Shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            Shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && BulletsLeft < MagazineSize && !Reloading)
        {
            Reload();
        }

        //Shoot
        if (ReadyToShoot && Shooting && !Reloading && BulletsLeft > 0)
        {
            BulletsShot = BulletsPerTap;
            Shoot();
        }
    }

    private void Shoot()
    {
        ReadyToShoot = false;
        BulletsLeft--;
        BulletsShot--;

        MuzzleFlash.Play();
        Instantiate(BulletHole, Hit.point, Quaternion.LookRotation(Hit.normal));

        //Spread

        float x = Random.Range(-Spread, Spread);
        float y = Random.Range(-Spread, Spread);

        Vector3 Direction = Cam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(Cam.transform.position, Direction, out Hit, Range, WhatIsEnemy))
        {
            Debug.Log(Hit.collider.name);

            if (Hit.collider.CompareTag("Enemy"))
            {
                Hit.collider.GetComponent<EnemyScript>().TakeDamage(Damage);
            }
        }

        Invoke("ResetShoot", TimeBetweenShooting);

        if (BulletsShot > 0 && BulletsLeft > 0)
        {
            Invoke("Shoot", TimeBetweenShots);
        }
    }

    private void ResetShoot()
    {
        ReadyToShoot = true;
    }

    private void Reload()
    {
        Reloading = true;
        Invoke("ReloadFinished", ReloadTime);
    }

    void ReloadFinished()
    {
        BulletsLeft = MagazineSize;

        Reloading = false;
    }
}