using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject gridObject;
    public string gridObjectName;

    public int gridX;
    public int gridZ;
    
    public float gridYOffset;
    public float gridSpacingOffset;
    public Vector3 gridOrigin = Vector3.zero;

    public bool spawnAroundOrigin = true;
    
    void Start()
    {
        SpawnGrid();
    }

    private void SpawnGrid()
    {

        if (spawnAroundOrigin)
        {
            for (var x = (int) (gridOrigin.x - gridX) + 1; x < (int) gridOrigin.x + gridX; x++)
            {
                for (var z = (int) (gridOrigin.z - gridZ) + 1; z < (int) gridOrigin.z + gridZ; z++) 
                {
                    SpawnObject(x, z);
                }
            }
        }
        else
        {
            for (var x = 0; x < gridX; x++)
            {
                for (var z = 0; z < gridZ; z++)
                {
                    SpawnObject(x, z);
                }
            }
        }
    }

    private void SpawnObject(int x, int z)
    {
        Vector3 spawnPos = new Vector3(x * gridSpacingOffset, gridYOffset, z * gridSpacingOffset) + gridOrigin;
        GameObject spawnObject = Instantiate(gridObject, spawnPos, Quaternion.identity, gameObject.transform);
        spawnObject.gameObject.name = gridObjectName + "[" + x + "," + z + "]";
    }
    
}
