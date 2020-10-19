using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Tower
{
    
    [Header("Specific Tower Attributes")]
    
    public bool isIdle;
    private float cooldownTimer;
    public Transform aimController;
    public Transform barrelController;
    public GameObject targetGameObject;
    public GameObject projectileObject;

    private void Start()
    {
        isIdle = true;
        towerSpeed = 10.0f;
        towerRange = 8.0f;
        towerDamage = 1.0f;
    }

    void Update()
    {
        var currentState = isIdle;
        var aim = aimController.transform;
        targetGameObject = FindClosestEnemy();

        if (targetGameObject == null)
        {
            return;
        }
        
        if (IsInRange(transform.position, targetGameObject.transform.position, towerRange))
        {
            isIdle = false;
            aim.transform.LookAt(targetGameObject.transform.position);
            FireProjectile();
        }
        else
        {
            isIdle = true;
            aim.transform.Rotate(Vector3.up * 50.0f * Time.deltaTime, Space.Self);
        }

        // Workaround to prevent rotation around x and z after lock-on
        if (currentState != isIdle)
        {
            aim.eulerAngles = new Vector3(0.0f, aim.eulerAngles.y, 0.0f);
        }
    }
    
    void FireProjectile()
    {
        if (cooldownTimer <= 0.0f)
        {
            var projectileGameObject = Instantiate(projectileObject, barrelController.transform.position, projectileObject.transform.rotation);
            var projectile = projectileGameObject.GetComponent<Projectile>();

            if (projectile != null)
            {
                projectile.ReceivedTowerInfo(gameObject, targetGameObject);
            }
            
            cooldownTimer = 1.0f / towerSpeed;
        }
        cooldownTimer -= Time.deltaTime;
    }
    
    private void OnDrawGizmos()
    {
        if (targetGameObject != null)
        {
            if (IsInRange(barrelController.transform.position, targetGameObject.transform.position, towerRange))
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(barrelController.transform.position, targetGameObject.transform.position);
            }
        }
    }
}