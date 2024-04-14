using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float positionSmoothing;
    public float rotationSmoothing;
    public Transform playerTransform;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, positionSmoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerTransform.rotation, rotationSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}