using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // Name of the item
    new public string name = "New Item";

    // Icon for the item in inventory
    public Sprite icon = null;
}
