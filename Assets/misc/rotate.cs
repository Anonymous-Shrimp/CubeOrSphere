using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(gameObject.transform.rotation.x, gameObject.transform.rotation.y + (speed * Time.deltaTime), gameObject.transform.rotation.z, Space.Self);
    }
}
