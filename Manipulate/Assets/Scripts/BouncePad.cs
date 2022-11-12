using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceHeight = 10f;
    public float bounceForce;
    private float gravity;
    public GameObject player;
    public bool hasRandomness = false;
    public float heightVariability = 20;
    public GameObject bounceEffect;
    public Vector3 direction;

    private void Start()
    {
        gravity = player.GetComponent<PlayerMovementController>().gravity;
        
    }





    private void OnTriggerEnter(Collider other)
    {
        CalculateBounce(other.transform.position.x, other.transform.position.z);
        

        Debug.Log("Bounce");

        if (other.transform.root.GetComponent<Rigidbody>() != null)
        {
            other.transform.root.GetComponent<Rigidbody>().AddForce(direction * bounceForce, ForceMode.Impulse);
        }
    }

    public void BouncePlayer()
    {
        CalculateBounce(player.transform.position.x, player.transform.position.z);
        player.GetComponent<PlayerMovementController>().velocity.y = direction.y * bounceForce;
        player.GetComponent<PlayerMovementController>().externalForces = direction * bounceForce;
    }

    private void CalculateBounce(float xPos, float zPos)
    {
        if (hasRandomness)
        {
            bounceForce = Mathf.Sqrt((bounceHeight + Random.Range(-heightVariability, heightVariability)) * -2f * gravity);
        } 
        else
        {
            bounceForce = Mathf.Sqrt(bounceHeight * -2f * gravity);
        }

        Vector3 bouncePos = transform.forward * zPos + transform.right * xPos + transform.GetChild(1).transform.position.y * transform.up;

        GameObject effect = Instantiate(bounceEffect, bouncePos, Quaternion.Euler(-90, 0, 0));
        effect.GetComponent<ParticleSystem>().Play();
    }
}
