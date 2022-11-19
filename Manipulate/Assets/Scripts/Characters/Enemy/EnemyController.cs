using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody hips;
    public LayerMask affected;


    public delegate void Ragdoll(bool state);
    public Ragdoll ragdoll;
    public float uprightTorque;

    private enum BALANCE_MODE { BALANCED, UNBALANCED };
    [SerializeField]
    private BALANCE_MODE balanceMode = BALANCE_MODE.BALANCED;


    // Start is called before the first frame update
    void Start()
    {
        hips.maxAngularVelocity = Mathf.Infinity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Balance();
    }

    public void Damage(float damage)
    {

    }

    void Balance()
    {
        switch(balanceMode)
        {
            case BALANCE_MODE.BALANCED:
                Quaternion rot = Quaternion.FromToRotation(hips.transform.up, Vector3.up);
                hips.AddTorque(new Vector3(rot.x, rot.y, rot.z) * uprightTorque * Time.fixedDeltaTime);

                //float angle = Vector3.SignedAngle(hips.transform.forward, TargetDirection, Vector3.up) / 180;

                //hips.AddRelativeTorque(0, percent * manualTorque, 0);

                ragdoll(true);
                break;

            case BALANCE_MODE.UNBALANCED:
                ragdoll(false);
                break;
        }
    }

    public IEnumerator FallDown()
    {

        balanceMode = BALANCE_MODE.UNBALANCED;

        yield return new WaitForSeconds(2f);

        balanceMode = BALANCE_MODE.BALANCED;
    }



}
