using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [Header("Position Where Cam Should Be")]
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
