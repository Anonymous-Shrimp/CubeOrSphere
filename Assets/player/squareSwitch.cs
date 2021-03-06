﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Ball;

public class squareSwitch : MonoBehaviour
{
    
    public bool issphere;
    public GameObject player;

    [Space]
    public GameObject cube;
    public CharacterController cubeRigid;
    public pickup cubePickup;
    [Space]
    public GameObject sphere;
    public Rigidbody sphereRigid;
    [Space]
    public CinemachineFreeLook cam;
    [Space]
    
    public Transform trail;
    public Transform pickup;
    public bool isGrounded = true;
    public Animator shapeIndicator;

    [HideInInspector]
    public bool canSwitch = true;

    
    // Start is called before the first frame update
    void Start()
    {
        cube.SetActive(true);
        cube.transform.position = sphere.transform.position;
        cam.Follow = cube.transform;
        cam.LookAt = cube.transform;
        sphere.SetActive(false);
        issphere = false;
        shapeIndicator.SetBool("issphere", issphere);



    }

    // Update is called once per frame
    void Update()
    {
        if (sphereRigid.velocity.magnitude != 0 && sphere.GetComponent<Ball>().isGrounded && issphere)
        {
            FindObjectOfType<AudioManager>().setVolume("Roll", Mathf.Clamp01(sphereRigid.velocity.magnitude));
        }
        else
        {
            FindObjectOfType<AudioManager>().setVolume("Roll", 0);
        }

        if (Input.GetMouseButtonDown(1) && canSwitch && isGrounded)
        {
            

            if (!issphere)
            {
                sphere.SetActive(true);
                sphere.transform.position = cube.transform.position;
                sphereRigid.velocity = new Vector3(cubeRigid.velocity.x, cubeRigid.velocity.y, cubeRigid.velocity.z);
                cam.Follow = sphere.transform;
                cam.LookAt = sphere.transform;
                cube.SetActive(false);
                issphere = true;
            }
            else
            {
                cube.SetActive(true);
                cube.transform.position = sphere.transform.position;
                cam.Follow = cube.transform;
                cam.LookAt = cube.transform;
                sphere.SetActive(false);
                issphere = false;
            }
            shapeIndicator.SetBool("issphere", issphere);
        }
        if (issphere)
        {
            sphere.SetActive(true);
            cube.SetActive(false);
            cube.transform.position = sphere.transform.position;
            trail.position = sphere.transform.position;
            cubePickup.box = null;
            cam.Follow = sphere.transform;
            cam.LookAt = sphere.transform;
            isGrounded = sphere.GetComponent<Ball>().isGrounded;
            FindObjectOfType<AudioManager>().setVolume("Slide", 0);
            if(sphereRigid.velocity.magnitude > 0.4 && isGrounded)
            {
                FindObjectOfType<AudioManager>().setVolume("Falling", 1);

            }
            else
            {
                FindObjectOfType<AudioManager>().setVolume("Falling", 0);
            }

        }
        else
        {
            cube.SetActive(true);
            sphere.SetActive(false);
            sphereRigid.velocity = new Vector3(cubeRigid.velocity.x, cubeRigid.velocity.y, cubeRigid.velocity.z);
            trail.position = cube.transform.position;
            cam.Follow = cube.transform;
            cam.LookAt = cube.transform;
            isGrounded = cubeRigid.isGrounded;
            FindObjectOfType<AudioManager>().setVolume("Roll", 0);
            if (sphereRigid.velocity.magnitude > 0.4 && isGrounded)
            {
                FindObjectOfType<AudioManager>().setVolume("Falling", 1);
            }
            else
            {
                FindObjectOfType<AudioManager>().setVolume("Falling", 0);
            }
        }
        shapeIndicator.SetBool("issphere", issphere);
        
        
    }
    
}
