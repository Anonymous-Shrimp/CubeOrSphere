using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToCamera : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = cam.rotation;
    }
}
