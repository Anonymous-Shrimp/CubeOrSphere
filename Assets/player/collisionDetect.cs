using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetect : MonoBehaviour
{
    public endTrigger triggerHost;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collide)
    {
        triggerHost.triggerEnter(collide);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        triggerHost.collisionEnter(collision);
    }
}
