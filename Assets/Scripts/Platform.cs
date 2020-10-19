using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer renderColor;
    private GameObject tower;

    public Vector3 towerOffset;
    
    // Cash the value here for optimizing
    void Start()
    {
        renderColor = GetComponent<Renderer>();
        startColor = renderColor.material.color;
    }
    
    void Update() {}

    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("You can't build there");
            return;
        }

        GameObject towerToBuild = BuildingController.instance.GetTowerToBuild();
        GameObject gunnerTower = Instantiate(towerToBuild, transform.position + towerOffset, transform.rotation);
        

    }

    private void OnMouseEnter()
    {
        renderColor.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderColor.material.color = startColor;
    }
}
