using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool balanced = true;
    public Rigidbody hips;
    public LayerMask affected;


    public delegate void Ragdoll(bool state);
    public Ragdoll ragdoll;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {

    }

    public void ToggleBalance()
    {
        if (balanced)
        {
            balanced = false;
            UnBalance();
        } else
        {
            balanced = true;
            Balance();
        }
    }

    void Balance()
    {


        ragdoll(true);
    }

    void UnBalance()
    {


        ragdoll(false);
    }

    public IEnumerator FallDown()
    {

        UnBalance();

        yield return new WaitForSeconds(2f);

        Balance();
    }
}
