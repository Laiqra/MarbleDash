using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugelBumper : MonoBehaviour
{
    public float force;
       private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red") || collision.gameObject.CompareTag("Blue") )
        { 
        Vector3 newvelocitySphere = -collision.contacts[0].normal.normalized * collision.relativeVelocity.magnitude * force;
        newvelocitySphere.y = 0f;
       
        
        collision.gameObject.GetComponent<Rigidbody>().AddForce(newvelocitySphere, ForceMode.Impulse);

        }
    }
}
