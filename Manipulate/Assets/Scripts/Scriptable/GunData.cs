using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Gun")]
public class GunData : WeaponData
{

    // General info about shooting
    [Header("Shooting Info")]
    public float maxDistance;

    // General info about reloading
    [Header("Reload Info")]
    public int currentAmmo;
    public int magSize;
    [Tooltip("In RPM")]
    public float fireRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
    


}
