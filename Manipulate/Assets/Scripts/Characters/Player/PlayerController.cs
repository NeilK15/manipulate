using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pushForce = 20f;
    private bool locationSet = false;
    private Vector3 setPosition;
    private Quaternion setRotation;
    private int flashBacks = 3;


    [Header("Pick Up Settings")]
    public float pickUpCircleRadius;
    public float pickUpDistance;
    public LayerMask itemLayer;

    private Camera cam;
    private PickUp focus = null;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (flashBacks > 0)
        {
            if (!locationSet)
                SetLocation();
            else
                Flashback();

            
        }

        PickUp();
    }

    private void SetLocation ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            print("HELLO");
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



    // Method for picking up items
    private void PickUp()
    {
        // Shoot sphere cast in direction of mouse check if intersecting with an item

        Vector3 direction = cam.transform.forward;

        RaycastHit hit;
        if (Physics.SphereCast(cam.transform.position, pickUpCircleRadius, direction, out hit, pickUpDistance, itemLayer))
        {

            // Getting the pickup from the object
            PickUp itemPickup = hit.collider.transform.root.GetComponent<PickUp>();

            if (itemPickup != null)
            {
                if (focus != itemPickup) {
                    focus = itemPickup;
                    itemPickup.Hover();
                }

                // Checking if pressing the use button
                if (Input.GetButtonDown("Use"))
                {
                    itemPickup.Interact();
                }
            }

        }
        else
        {
            if (focus != null)
            {
                focus.UnHover();

                focus = null;
            }
        }

    }

}
