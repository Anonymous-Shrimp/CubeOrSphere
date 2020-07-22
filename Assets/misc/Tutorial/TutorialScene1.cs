using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScene1 : MonoBehaviour
{
    
    public Animator directions;
    public squareSwitch playerManager;
    GameObject player;
    public PlayerController playerCube;
    public string[] texts;
    public Text popupText;
    int popUpIndex = 0;
    float waitTime = 2f;
    bool collisionTrigger = false;
    
    // Start is called before the first frame update
    void Start()
    {
        directions.SetBool("Faded", true);
        playerCube.canMove = false;
        playerCube.canJump = true;
        playerManager.canSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.issphere)
        {
            player = playerManager.sphere;
        }
        else
        {
            player = playerManager.cube;
        }
        popupText.text = texts[popUpIndex];
        if (popUpIndex == 0)
        {
            if (waitTime <= 0)
            {
                waitTime = 2f;
                playerCube.canMove = true;
                directions.SetBool("Faded", false);
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }else if (popUpIndex == 1){
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
        }else if(popUpIndex == 2)
        {
            if (collisionTrigger)
            {
                directions.SetBool("Faded", false);
                playerCube.canJump = true;
                collisionTrigger = false;
                popUpIndex++;
            }
            
        }else if(popUpIndex == 3)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
        }else if(popUpIndex == 4)
        {
            directions.SetBool("Faded", true);
            if (collisionTrigger)
            {
                directions.SetBool("Faded", false);
                playerManager.canSwitch = true;
                popUpIndex++;
            }
        }
        else if(popUpIndex == 5)
        {
            if (Input.GetMouseButton(1))
            {
                directions.SetBool("Faded", true);
                collisionTrigger = false;
            }
        }
        
    }
    public void collisionTriggered(bool trigger)
    {
        collisionTrigger = trigger;
    }

}
