using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(50.0f * Time.deltaTime,50.0f * Time.deltaTime,50.0f * Time.deltaTime);
    }
    
}
