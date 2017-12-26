using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRectGizmo : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.25f);
        Gizmos.DrawCube(transform.position + Vector3.up * 10, Vector3.one * 20);
    }
}
