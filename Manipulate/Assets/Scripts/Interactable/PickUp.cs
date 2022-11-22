using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public Outline[] outlines;

    public Color outLineColor = Color.red;
    private static Color defaultOutline = Color.white;

    public void Interact()
    {
        print("Picking up " + gameObject.name);
    }

    public void Hover()
    {
        print("Hovering");
        foreach (Outline outline in outlines)
            outline.OutlineColor = outLineColor;
    }

    public void UnHover()
    {
        print("UnHovering");
        foreach (Outline outline in outlines)
            outline.OutlineColor = defaultOutline;
    }

}
