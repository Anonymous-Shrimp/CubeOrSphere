using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public bool isFirstPerson = false;
    public GameObject[] disabledOnFPC;
    public GameObject[] enabledOnFPC;
    [Space]
    public PlayerController cube;
    public squareSwitch controller;
    [Space]
    public CinemachineFreeLook TPC;
    public CinemachineFreeLook FPC;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isFirstPerson = !isFirstPerson;
            foreach (GameObject s in disabledOnFPC)
            {
                s.SetActive(!isFirstPerson);
            }
            foreach (GameObject s in enabledOnFPC)
            {
                s.SetActive(isFirstPerson);
            }
            if (isFirstPerson)
                cube.RotationSpeed = 1000;
            controller.cam = FPC;

        }
        else
        {
            cube.RotationSpeed = 240;
            controller.cam = TPC;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isFirstPerson = !isFirstPerson;
            foreach (GameObject s in disabledOnFPC)
            {
                s.SetActive(!isFirstPerson);
            }
            foreach (GameObject s in enabledOnFPC)
            {
                s.SetActive(isFirstPerson);
            }
            if (isFirstPerson)
                cube.RotationSpeed = 1000;
            controller.cam = FPC;

        }
        else
        {
            cube.RotationSpeed = 240;
            controller.cam = TPC;
        }
        
        

    }
}
