using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [Header("Targeting Objects")]
    public GameObject sender;
    public GameObject target;
    public GameObject impactEffect;
    
    [Header("Projectile Properties")]
    public float targetAccuracy = 0.1f;
    public float projectileSpeed = 20.0f;
    
    public void ReceivedTowerInfo(GameObject _sender, GameObject _target)
    {
        sender = _sender;
        target = _target;
    }
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        MoveProjectile();
    }
    
    void MoveProjectile()
    {
        // Rotate projectile towards target
        transform.LookAt(target.transform);

        // Move projectile towards target
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);

        // Hit detection
        if(Math.Abs(transform.position.x - target.transform.position.x) < targetAccuracy && Math.Abs(transform.position.z - target.transform.position.z) < targetAccuracy)
        {
            GameObject effectProjectile = Instantiate(impactEffect, transform.position, transform.rotation);
            target.GetComponent<Enemy>().EnemyHealth -= sender.GetComponent<Tower>().towerDamage;
            Destroy(gameObject);
            Destroy(effectProjectile, 2.0f);
        }
    }
    
}
