using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float hitForce = 300f;
    public float damage = 100f;
    private void Start()
    {
        StartCoroutine("SelfDestruct");
    }


    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>());
            Debug.Log("PLAYER HIT SHOULD NOT BE HAPPENING!!!");
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<EnemyController>().Damage(damage);
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.impulse * -hitForce);
            Debug.Log(other.gameObject.name);
        } else
        {
            Debug.Log(other.gameObject.name);
        }

        

    }

    public IEnumerator SelfDestruct()
    {
        if (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}
