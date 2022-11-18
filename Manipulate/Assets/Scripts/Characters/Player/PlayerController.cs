using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pushForce = 20f;
    private bool locationSet = false;
    private Vector3 setPosition;
    private Quaternion setRotation;
    private int flashBacks = 3;

    private void Update()
    {
        if (flashBacks > 0)
        {
            if (!locationSet)
                SetLocation();
            else
                Flashback();

            
        }
    }

    private void SetLocation ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            setPosition = transform.position;
            setRotation = transform.rotation;
            locationSet = true;
            
        }
    }

    private void Flashback()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.position = setPosition;
            transform.rotation = setRotation;
            locationSet = false;
            flashBacks--;
        }
    }

}
