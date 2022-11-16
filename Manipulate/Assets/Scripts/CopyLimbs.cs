using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyLimbs : MonoBehaviour
{

    public Transform targetLimb;

    private ConfigurableJoint joint;

    Quaternion targetInitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        targetInitialRotation = targetLimb.localRotation;
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

}
