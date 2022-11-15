using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementPhysics : MonoBehaviour
{
    [Header("Movement Settings")]
    public float acceleration;
    public float maxSpeed;

    [Space(10)]
    public float jumpForce;

    [Space(10)]
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundCheck;
    private bool grounded;


    [Header("Other Required Fields")]
    public Transform orientation;

    // Other Private fields
    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundCheck);

        MyInput();

        LimitSpeed();

        Drag();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void Move()
    {

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * acceleration * Time.deltaTime * rb.mass, ForceMode.Force);

    }

    private void Drag()
    {
        if (grounded)
        {
            rb.drag = groundDrag;
        } 
        else
        {
            rb.drag = 0;
        }
    }

    private void LimitSpeed()
    {
        
        // Getting flat velocity
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Checking if travelling too fast
        if (flatVelocity.magnitude > maxSpeed)
        {
            Vector3 maxVelocity = flatVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(maxVelocity.x, rb.velocity.y, maxVelocity.z);
        }

    }


}

