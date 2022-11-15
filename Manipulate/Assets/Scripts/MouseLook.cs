using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    // Public fields
    [Header("Required Settings")]
    public Vector2 mouseSensitivity;
    public Transform playerBody;
    public Transform orientation;

    // Private fields
    private float xRotation = 0f;
    private float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Locking cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting input and multiplying my sensitivity
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
        //transform.GetComponent<CameraShaker>().RestRotationOffset = transform.localRotation.eulerAngles;

        //playerBody.Rotate(Vector3.up * mouseX);
        
    }

}
