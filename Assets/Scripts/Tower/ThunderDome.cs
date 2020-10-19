using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderDome : Tower
{
    
    public float pulse;
    public float timer;
    public bool switcher;
    private void Start()
    {
        towerRange = 4.0f;
        towerDamage = 3.0f;
        InvokeRepeating(nameof(DamageEnemyInRange), 1.1f, 1.0f);
    }

    void DamageEnemyInRange()
    {
        var tagged = GameObject.FindGameObjectsWithTag("EnemyTag");
        
        foreach (var targetEnemy in tagged)
        {
            if (IsInRange(transform.position, targetEnemy.transform.position, towerRange))
            {
                targetEnemy.GetComponent<Enemy>().EnemyHealth -= towerDamage;
            }
        }
    }
    
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= 1f) {
            timer %= 1f;
            switcher = true;
        }

        if (switcher)
        {
            if (pulse < towerRange)
            {
                pulse += 0.25f;
            }
            else
            {
                pulse = 0.0f;
                switcher = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position , transform.up, pulse);
    }
}
