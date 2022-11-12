using UnityEngine;

public class PlayerMovementPhysics : MonoBehaviour
{

    public float speed = 100000f;
    public float maxSpeed = 20f;
    public float jumpForce = 300f;

    private float threshold = 0.01f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float counterMovement = 0.375f;
    private bool jumping;

    float x;
    float z;

    bool isGrounded;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {

        Movement();
        
    }

    void Movement()
    {
        // Extra Grav
        rb.AddForce(Vector3.down * 10f * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (jumping && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        }

        CounterMovement(x, z, FindVelRelativeToLook());

        rb.AddForce(transform.right * speed * x * Time.deltaTime);
        rb.AddForce(transform.forward * speed * z * Time.deltaTime);
        rb.velocity  = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

    }

    void GetInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        jumping = Input.GetButton("Jump");
    }

    private void CounterMovement(float x, float y, Vector2 mag)
    {
        if (!isGrounded || jumping) return;

        if (Mathf.Abs(mag.x) > threshold && Mathf.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            rb.AddForce(speed * transform.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Mathf.Abs(mag.y) > threshold && Mathf.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            rb.AddForce(speed * transform.forward * Time.deltaTime * -mag.y * counterMovement);
        }

        if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxSpeed)
        {
            float fallspeed = rb.velocity.y;
            Vector3 n = rb.velocity.normalized * maxSpeed;
            rb.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }

    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }

}

