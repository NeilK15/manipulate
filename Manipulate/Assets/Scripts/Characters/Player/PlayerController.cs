using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool locationSet = false;
    private Vector3 setPosition;
    private Quaternion setRotation;
    private int flashBacks = 3;


    [Header("Pick Up Settings")]
    public float pickUpCircleRadius;
    public float pickUpDistance;
    public LayerMask interactableLayer;

    [Header("For Visualizing Interaction")]
    public Transform pointer;
    public bool usePointer = false;

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

        Interact();
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



    // Method for interacting with items
    private void Interact()
    {
        // Shoot sphere cast in direction of mouse check if intersecting with an item

        Vector3 direction = cam.transform.forward;

        RaycastHit hit;
        if (Physics.SphereCast(cam.transform.position, pickUpCircleRadius, direction, out hit, pickUpDistance, interactableLayer))
        {

            IInteractable interactable = hit.transform.GetComponent<IInteractable>();

            if (interactable != null)
            {

                // Behavior when hovering over an interactable
                if (usePointer)
                {
                    pointer.gameObject.SetActive(true);
                    pointer.position = hit.point;
                }

                if (Input.GetButtonDown("Interact"))
                {
                    // Behavior when interacting
                    interactable.Interact();
                }

            }

            

        }
        else
        {
            
            if (usePointer)
            pointer.gameObject.SetActive(false);

            if (focus != null)
            {
                focus.UnHover();

                focus = null;
            }
        }

    }

}
