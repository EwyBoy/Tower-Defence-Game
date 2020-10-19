using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float EnemyHealth = 10;
    public float EnemySpeed = 10;

    public GameObject[] WayPointsList;
    public int CurrentWayPoint = 0;
    public GameObject TargetWayPoint;

    void Start() {}

    void Update()
    {
        
        // Pathfinding
        if (CurrentWayPoint < WayPointsList.Length)
        {
            if (TargetWayPoint != null)
            {
                TargetWayPoint = WayPointsList[CurrentWayPoint];
            }
            MoveEnemy();
        }

        if (EnemyHealth <  5)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        
     
        // Health
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void MoveEnemy()
    {
        var enemy = transform.position;
        var forward = transform.forward;
        var target = TargetWayPoint.transform.position;
        
        // Rotation
        transform.forward = Vector3.RotateTowards(forward, target - enemy, EnemySpeed * Time.deltaTime, 0.0f);

        // Movement
        transform.position = Vector3.MoveTowards(enemy, target, EnemySpeed * Time.deltaTime);
        
        if(Math.Abs(enemy.x - target.x) < 0.1 && Math.Abs(enemy.z - target.z) < 0.1)
        {
            if (CurrentWayPoint < WayPointsList.Length)
            {
                TargetWayPoint = WayPointsList[CurrentWayPoint];
                CurrentWayPoint++;
                Debug.Log(CurrentWayPoint + " / " + WayPointsList.Length);
            }
        }
    }
}
