using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desired = target.position + offset;

        Vector3 smooth = Vector3.Lerp(transform.position, desired, smoothSpeed);
        transform.position = smooth;

        transform.LookAt(target);
    }
}
