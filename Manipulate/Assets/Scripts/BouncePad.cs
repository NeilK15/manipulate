using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce;
    public GameObject player;
    public bool hasRandomness = false;
    public float heightVariability = 20;
    public GameObject bounceEffect;
    public Vector3 direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<Rigidbody>() != null)
        {
            other.transform.root.GetComponent<Rigidbody>().AddForce(direction * bounceForce, ForceMode.Impulse);
        }
    }

}
