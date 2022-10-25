using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class WeaponSelectThing : MonoBehaviour
{
    public GameObject AK47, SVD;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Deploy()
    {
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SelectAK()
    {
        AK47.SetActive(true);
        SVD.SetActive(false);
    }
    public void SelectSVD()
    {
        AK47.SetActive(false);
        SVD.SetActive(true);
    }
}
