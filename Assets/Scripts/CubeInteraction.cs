using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] Color gizmoColor = new Color(0,0,0,0);
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), new Vector3(1,1,1));
    }
}
