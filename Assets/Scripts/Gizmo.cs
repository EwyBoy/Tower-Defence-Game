using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{

    public string GizmoName = "Gizmo";
    public float GizmoRadius = 1.0f;
    public Color GizmoColor = Color.white;
    public GameObject LinkedNode;
    private Vector3 LastPos;
    
    void Start()
    {
        LastPos = transform.position;
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = GizmoColor;
        Gizmos.DrawSphere(LastPos, GizmoRadius);

        // Generates Gizmo Object Name
        if (LastPos != transform.position)
        {
            LastPos = transform.position;
            gameObject.name = GizmoName + ":" + LastPos;
        }

        // Draws pathfinding path
        if (LinkedNode != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, LinkedNode.transform.position);
        }
    }
}
