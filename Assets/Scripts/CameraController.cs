using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [Header("Movement Settings")]
    public float panSpeed = 30.0f;
    public bool toggleLockedCamera = true;
    
    private CameraController controller;
    
    [Header("Scroll Settings")]
    public float scrollSpeed = 2000f;
    public float cameraScrollDistanceMin = 30.0f;
    public float cameraScrollDistanceMax = 200.0f;

    void Start()
    {
        controller = GetComponent<CameraController>();
    }

    // Add delta time camera movement
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleLockedCamera = !toggleLockedCamera;
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 pos = transform.position;
            var scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
            
            pos -= new Vector3(scroll,scroll, scroll);
            pos = new Vector3(Mathf.Clamp(pos.x, cameraScrollDistanceMin, cameraScrollDistanceMax), Mathf.Clamp(pos.y, cameraScrollDistanceMin, cameraScrollDistanceMax), Mathf.Clamp(pos.z, cameraScrollDistanceMin, cameraScrollDistanceMax));
            
            transform.position = pos;
        }
        
        if (!toggleLockedCamera) return;
        
        controller.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}
