using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBumper : MonoBehaviour
{
       private void OnCollisionEnter(Collision collision)
    {
        Vector3 newvelocitySphere = -collision.contacts[0].normal.normalized * collision.relativeVelocity.magnitude * 3/4;
        newvelocitySphere.y = 0f;
        
        collision.gameObject.GetComponent<Rigidbody>().AddForce(newvelocitySphere, ForceMode.Impulse);

    }
}
