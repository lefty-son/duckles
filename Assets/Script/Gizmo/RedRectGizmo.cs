using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRectGizmo : MonoBehaviour {
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawCube(transform.position + Vector3.up * 5, Vector3.one * 10);
    }
}
