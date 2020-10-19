using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [Header("General Tower Attributes")]
    
    public int towerCost;
    public int towerLevel;
    public float towerSpeed;
    public float towerRange;
    public float towerDamage;

    public static bool IsInRange(Vector3 pos, Vector3 targetPos, float range)
    {
        return Vector3.Distance(pos, targetPos) < range;
    }
    
    public GameObject FindClosestEnemy()
    {
        var tagged = GameObject.FindGameObjectsWithTag("EnemyTag");
        
        GameObject closest = null;
        var distance = Mathf.Infinity;
        var position = transform.position;
        
        foreach (var go in tagged)
        {
            var diff = go.transform.position - position;
            var curDistance = diff.sqrMagnitude;
            if (!(curDistance < distance)) continue;
            closest = go;
            distance = curDistance;
        }
        
        return closest;
    }


    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position , transform.up, towerRange);
    }
}
