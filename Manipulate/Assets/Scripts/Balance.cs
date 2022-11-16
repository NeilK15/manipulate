using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform hipsPos;

    public Transform hipsTarget;

    public ConfigurableJoint headJoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        headJoint.targetPosition = new Vector3(hipsPos.position.x, hipsTarget.position.y, hipsPos.position.z);
    }
}
