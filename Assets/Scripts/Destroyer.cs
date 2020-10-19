using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject target;
    
    void Update()
    {
        target = FindClosestEnemy();

        if (target == null)
        {
            return;
        }

        if (IsInRange(transform.position, target.transform.position))
        {
            Destroy(target);
        }
    }
    
    private bool IsInRange(Vector3 pos, Vector3 targetPos)
    {
        return Vector3.Distance(pos, targetPos) < 1.0f;
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
}
