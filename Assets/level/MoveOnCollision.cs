using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCollision : MonoBehaviour
{
    public Transform door;
    public Vector3 defaultPos;
    public Vector3 movedPos;
    public float moveTime;


    private void Start()
    {
        while (door.position != defaultPos)
        {
            door.position = Vector3.MoveTowards(door.position, defaultPos, moveTime);
        }
    }
    private void OnTriggerEnter(Collider collide)
    {
        if(collide.gameObject.CompareTag("Box") || collide.gameObject.CompareTag("Player"))
        {
            StartCoroutine(activateDoor(true));
        }
        else
        {
            StartCoroutine(activateDoor(false));
        }
    }

    IEnumerator activateDoor(bool open)
    {
        if (open)
        {
            while (door.position != movedPos)
            {
                door.position = Vector3.MoveTowards(door.position, movedPos, moveTime * Time.deltaTime);
            }
        }
        else
        {
            while (door.position != defaultPos)
            {
                door.position = Vector3.MoveTowards(door.position, defaultPos, moveTime * Time.deltaTime);
            }
        }
        yield return null;
    }
    
}
