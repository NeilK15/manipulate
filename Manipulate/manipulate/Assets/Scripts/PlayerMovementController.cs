using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController charC;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public Vector3 externalForces;
    bool isGrounded;
    bool isJumping;

    // Start is called before the first frame update

    void Start()

    {

        charC = GetComponent<CharacterController>();

    }


    // Update is called once per frame

    void Update()
    {

        Move();

    }


    void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.forward * z + transform.right * x;
        //charC.Move(move * speed * Time.deltaTime);
        move *= speed;
        velocity.x = move.x + externalForces.x;
        velocity.z = move.z + externalForces.z;
        Jump();

        

        charC.Move(velocity * Time.deltaTime);

    }

    void Jump()
    {
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
            externalForces = Vector3.Lerp(externalForces, Vector3.zero, 0.07f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            Debug.Log("Jumped");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
    }


}

