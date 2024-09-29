using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public Transform target;

    public float cameraSpeed;
    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z), cameraSpeed);
    }
}
