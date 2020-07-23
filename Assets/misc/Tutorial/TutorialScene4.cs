using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene4 : MonoBehaviour
{
    public PlayerController cube;
    public squareSwitch player;
    public bool controllable = false;
    public GameObject mainCamera;
    
    

    // Start is called before the first frame update
    void Start()
    {
        cube.canMove = false;
        cube.canJump = false;
        player.canSwitch = false;
        mainCamera.SetActive(false) ;

    }
    private void Update()
    {
        cube.canMove = controllable;
        cube.canJump = controllable;
        player.canSwitch = controllable;
        mainCamera.SetActive(controllable);
    }

    
}




