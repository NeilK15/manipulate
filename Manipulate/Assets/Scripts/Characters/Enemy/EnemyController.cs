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
    public float uprightTorque;

    private enum BALANCE_MODE { BALANCED, UNBALANCED };


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
            Balance(BALANCE_MODE.UNBALANCED);
        } else
        {
            balanced = true;
            Balance(BALANCE_MODE.BALANCED);
        }
    }

    void Balance(BALANCE_MODE balance_mode)
    {
        switch(balance_mode)
        {
            case BALANCE_MODE.BALANCED:
                Quaternion rot = Quaternion.FromToRotation(hips.transform.up, Vector3.up);
                hips.AddTorque(new Vector3(rot.x, rot.y, rot.z) * -uprightTorque);

                //float angle = Vector3.SignedAngle(hips.transform.forward, TargetDirection, Vector3.up) / 180;

                ragdoll(true);
                break;

            case BALANCE_MODE.UNBALANCED:
                ragdoll(false);
                break;
        }
    }

    public IEnumerator FallDown()
    {

        Balance(BALANCE_MODE.UNBALANCED);

        yield return new WaitForSeconds(2f);

        Balance(BALANCE_MODE.BALANCED);
    }



}
