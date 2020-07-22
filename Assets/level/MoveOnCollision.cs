using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveOnCollision : MonoBehaviour
{
    public Animator doorAnim;
    public bool closed = true;
    public bool multiplePads = false;
    public doorManager doorManager;
    public GameObject[] objectsOnPad;
    public int padNo;
    public Material padNormal;
    public Material padActivated;
    public Renderer objects;
    public bool boxOn;
    public bool playerOn;

    
    private void Update()
    {
        if (!multiplePads)
        {
            doorAnim.SetBool("Closed", closed);
        }
        
    }
    private void FixedUpdate()
    {
        if(boxOn || playerOn)
        {
            closed = false;
        }
        else
        {
            closed = true;
        }

        if (multiplePads)
        {
            if (padNo == 1)
            {
                doorManager.pad1 = closed;
            }
            else if (padNo == 2)
            {
                doorManager.pad2 = closed;
            }
        }
        if (closed)
        {
            objects.material = padNormal;
        }
        else
        {
            objects.material = padActivated;
        }
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            boxOn = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            boxOn = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }
}
