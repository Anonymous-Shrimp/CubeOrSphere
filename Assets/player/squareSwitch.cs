using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class squareSwitch : MonoBehaviour
{
    public bool issphere;
    public GameObject cube;
    public GameObject sphere;
    public thirdPersonCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        
            sphere.SetActive(true);
            sphere.transform.position = cube.transform.position;
            cam.Target = sphere.transform;
            cube.SetActive(false);
        issphere = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            if (!issphere)
            {
                sphere.SetActive(true);
                sphere.transform.position = cube.transform.position;
                cam.Target = sphere.transform;
                cube.SetActive(false);
                issphere = true;
            }
            else
            {
                cube.SetActive(true);
                cube.transform.position = sphere.transform.position;
                cam.Target = cube.transform;
                sphere.SetActive(false);
                issphere = false;
            }
        }
        if (issphere)
        {
            sphere.SetActive(true);
            cube.SetActive(false);
        }
        else
        {
            cube.SetActive(true);
            sphere.SetActive(false);
        }
    }
}
