using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce;
    public GameObject bounceEffect;

    public float cooldownTime = 2;

    float nextBounceTime = 0;



    Vector3 boxCastPosition;


    /*
private void OnTriggerEnter(Collider other)
{
    // CHANGE THIS UP LATER
    Rigidbody footScenario = other.GetComponentInParent<Rigidbody>();

    if (footScenario != null)
    {
        footScenario.AddForce(direction * bounceForce, ForceMode.Impulse);

    }


    if (other.transform.root.GetComponent<Rigidbody>() != null)
    {
        other.transform.root.GetComponent<Rigidbody>().AddForce(direction * bounceForce, ForceMode.Impulse);
    }

    Rigidbody rb = other.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.AddForce(direction * bounceForce, ForceMode.Impulse);

        Debug.Log(other.name);
    }
}
    */



    private void Update()
    {
        boxCastPosition = new Vector3(0, Mathf.Abs(transform.localScale.y) / 2, 0) + transform.position;

        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale/2, transform.rotation);

        foreach (Collider collider in colliders)
        {
            if (collider != null)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Bounce(rb);
                }

                Rigidbody parentRb = collider.GetComponentInParent<Rigidbody>();
                if (parentRb != null)
                {
                    Bounce(parentRb);
                }

            }
        }
    }


    public void Bounce(Rigidbody rb)
    {
        if (Time.time > nextBounceTime)
        {
            rb.AddForce(bounceForce * transform.up, ForceMode.Impulse);
            nextBounceTime = Time.time + cooldownTime;
            Debug.Log(rb.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        boxCastPosition = new Vector3(0, Mathf.Abs(transform.localScale.y) / 2, 0) + transform.position;

        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(boxCastPosition, transform.localScale);
    }


}
