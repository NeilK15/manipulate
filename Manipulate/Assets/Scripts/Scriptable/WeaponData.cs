using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Weapon")]
public class WeaponData : EquipmentData
{

    // Info specific to weapons
    [Header("Weapon Info")]
    public float damageModifier;
    public WeaponType weaponType;

}


public enum WeaponType { Melee, Ranged } 