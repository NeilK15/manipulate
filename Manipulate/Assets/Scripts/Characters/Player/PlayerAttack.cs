using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector]
    public static Action shootInput;
    [HideInInspector]
    public static Action reloadInput;

    public static WeaponData activeWeapon;

    public KeyCode reloadKey;

    private void Update()
    {
        
        
        if (Input.GetButtonDown("Fire1"))
        {
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput?.Invoke();
        }
    }



}
