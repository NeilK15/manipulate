using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{

    // Name of the item
    [Header("Generic Info")]
    new public string name = "New Item";
    // Icon for the item in inventory
    public Sprite icon = null;

}
