using UnityEngine;

public class PickUp : Interactable
{
    public Outline[] outlines;

    public Color outLineColor = Color.red;
    private static Color defaultOutline = Color.white;


    public override void Interact()
    {
        base.Interact();
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
