using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLimbs : MonoBehaviour
{

    public Transform targetLimb;
    public GameObject enemy;

    private ConfigurableJoint joint;
    private EnemyController controller;

    Quaternion targetInitialRotation;

    float initialAngularXSpring;
    float initialAngularYZSpring;
    LayerMask objects;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        targetInitialRotation = targetLimb.localRotation;
        initialAngularXSpring = joint.angularXDrive.positionSpring;
        initialAngularYZSpring = joint.angularYZDrive.positionSpring;
        controller = enemy.GetComponent<EnemyController>();

        if (controller != null)
        {
            controller.ragdoll += CanMove;
            objects = controller.affected;
        }
    }

    // Update is called once per frame
    void Update()
    {
        joint.targetRotation = CopyRotation();
    }

    private void FixedUpdate()
    {
        
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(targetLimb.localRotation) * targetInitialRotation;
    }

    public void CanMove(bool state)
    {
        if (joint != null)
        {
            if (state)
            {
                JointDrive driveX = new JointDrive();
                JointDrive driveYZ = new JointDrive();
                driveX.maximumForce = Mathf.Infinity;
                driveYZ.maximumForce = Mathf.Infinity;
                driveX.positionSpring = initialAngularXSpring;
                driveYZ.positionSpring = initialAngularYZSpring;

                joint.angularXDrive = driveX;
                joint.angularYZDrive = driveYZ;
            } else
            {
                JointDrive drive = new JointDrive();
                drive.maximumForce = 0;

                joint.angularXDrive = drive;
                joint.angularYZDrive = drive;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if ((objects.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            Debug.Log(collision.relativeVelocity);
            //StartCoroutine(controller.FallDown());
            Debug.Log(collision.gameObject.name);
        }
    }


}
