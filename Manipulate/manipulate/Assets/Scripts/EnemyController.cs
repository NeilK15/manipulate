using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 100f;

    public Animator anim;

    public void SetKinematic(bool status)
    {
        foreach (Rigidbody rb in gameObject.GetComponentsInChildren<Rigidbody>())
        {
            gameObject.GetComponent<Animator>().enabled = false;
            rb.isKinematic = status;
        }
    }

    public void Damage (float amt)
    {
        health -= amt;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        SetKinematic(false);
    }

}
