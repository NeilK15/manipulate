using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{

    [Header("Interaction Specifics")]
    public Animation pressAnimation;
    public ParticleSystem pressEffect;

    [HideInInspector]
    public delegate void OnButtonPress();

    [HideInInspector]
    public event OnButtonPress onButtonPress;

    // Called when player interacts with button
    public void Interact()
    {
        // Play pressEffect
        if (!pressAnimation.isPlaying)
            pressEffect?.Play();

        // Play pressAnimation
        pressAnimation?.Play();

    }

    // Called when button finished pressing
    public void Pressed()
    {
        print("Yo I was pressed - " + transform.name);

        // Calling the delegate
        if (onButtonPress != null)
            onButtonPress();
    }

}
