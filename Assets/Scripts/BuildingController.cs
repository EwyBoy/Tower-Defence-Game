using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{

    public static BuildingController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple building managers in the scene!");
            return;
        }
        instance = this;
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
    
    public GameObject gunnerTower;
    public GameObject thunderDomeTower;

    private void Start()
    {
        towerToBuild = gunnerTower;
    }
}
