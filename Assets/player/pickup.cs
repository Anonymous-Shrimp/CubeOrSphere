using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class pickup : MonoBehaviour
{
    
    public GameObject box;
    Rigidbody curBody;
    bool pickedup = false;
    public float dist = 2.5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (box != null && !pickedup)
            {
                pickedup = true;
            }
            else if (pickedup)
            {
                pickedup = false;
            }
        }
        if(box == null)
        {
            pickedup = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box")){
            box = other.gameObject;
            curBody = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box = null;
        }
    }
    void FixedUpdate()
    {
        if (pickedup && box != null)
        {
            //keep the object in front of the camera
            ReposObject();
        }
    }

    //calculates the new rotation and position of the box
    void ReposObject()
    {
        //calculate the target position and rotation of the curbody
        Vector3 targetPos = transform.position + transform.forward * dist;
        Quaternion targetRot = transform.rotation;

        //interpolate to the target position using velocity
        curBody.velocity = (targetPos - curBody.position) * 10;

        //keep the relative rotation the same
        curBody.rotation = targetRot;

        //no spinning around
        curBody.angularVelocity = Vector3.zero;
    }

    //attempts to pick up an item straigth ahead
    

    //drops the current item
    void DropItem()
    {
        curBody.useGravity = true;
        curBody = null;
        box = null;
    }
}
