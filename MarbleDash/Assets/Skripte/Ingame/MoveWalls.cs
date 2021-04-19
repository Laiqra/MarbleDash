using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    
    void Awake()
    {
      
    }

    void FixedUpdate()
    {
        
        transform.Translate((Mathf.Sin(Time.time)) * 0.1f, 0, 0, Space.Self);

    }
}