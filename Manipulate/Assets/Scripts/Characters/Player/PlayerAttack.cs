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

    public KeyCode reloadKey;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput?.Invoke();
        }
    }



}
