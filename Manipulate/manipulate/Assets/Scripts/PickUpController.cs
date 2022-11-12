using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform theDest;
    public Camera fpsCam;

    [SerializeField]
    private Vector3 desiredPosition;

    [SerializeField]
    private Vector3 desiredRotation;


    public static float dropForce = 35f;

    private GameObject player;

    public static float pickupRange = 18f;


    [SerializeField]
    private static bool isPickedUp = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (!isPickedUp)
            PickUpWeapon();
        else
        {
            DropWeapon();
        }
        Debug.Log(player.GetComponent<CharacterController>().velocity.magnitude);
    }

    private void PickUpWeapon ()
    {
        

        if (Input.GetKeyDown("e"))
        {
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange))
            {
                if (hit.collider.tag == "Weapon")
                {
                    // Enter Specific Info For Activating Weapon

                    GameObject gameObject = hit.collider.transform.root.gameObject;

                    Weapon weapon = gameObject.GetComponent<Weapon>();
                    PickUpController controller = gameObject.GetComponent<PickUpController>();
                    Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
                    Collider collider = gameObject.GetComponent<Collider>();
                    Animator animator = gameObject.GetComponent<Animator>(); 
                    
                    if (weapon != null)
                        weapon.enabled = true;

                    if (rigidbody != null)
                    {
                        rigidbody.velocity = Vector3.zero;
                        rigidbody.useGravity = false;
                        //rigidbody.isKinematic = true;
                    }

                    if (collider != null)
                        collider.enabled = false;

                    foreach (Collider col in gameObject.GetComponentsInChildren<Collider>())
                        col.enabled = false;

                    if (animator != null)
                        animator.enabled = true;


                    gameObject.transform.parent = theDest;
                    gameObject.transform.localPosition = controller.desiredPosition;
                    Debug.Log("Desired Rotation: " + desiredRotation);
                    Quaternion target = Quaternion.Euler(controller.desiredRotation);
                    gameObject.transform.localEulerAngles = controller.desiredRotation;


                    isPickedUp = true;

                }
            }
        }
    }

    private void DropWeapon()
    {
        if (Input.GetKeyDown("q"))
        {
            Debug.Log("Weapon Dropped!");
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            GameObject gameObject = theDest.GetChild(0).gameObject;

            Weapon weapon = gameObject.GetComponent<Weapon>();
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            Collider collider = gameObject.GetComponent<Collider>();
            Animator animator = gameObject.GetComponent<Animator>();

            if (weapon != null)
                weapon.enabled = false;

            if (rigidbody != null)
            {
                rigidbody.useGravity = true;
                //rigidbody.isKinematic = false;
                rigidbody.AddForce(ray.direction * (dropForce + player.GetComponent<PlayerMovementController>().velocity.magnitude) , ForceMode.Impulse);
                rigidbody.AddTorque(Random.rotation.eulerAngles, ForceMode.Impulse);
            }

            if (collider != null)
                collider.enabled = true;

            foreach (Collider col in gameObject.GetComponentsInChildren<Collider>())
                col.enabled = true;

            if (animator != null)
                animator.enabled = false;

            gameObject.transform.parent = null;
            isPickedUp = false;

        }
    }
}
