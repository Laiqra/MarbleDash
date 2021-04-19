using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallsMainMenu : MonoBehaviour
{

    void FixedUpdate()
    {
        
        transform.Translate((Mathf.Sin(Time.time)) * 3f, 0, 0, Space.Self);
    }
}