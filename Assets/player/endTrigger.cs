using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Ball;

public class endTrigger : MonoBehaviour
{
    public loading levelLoader;
    public squareSwitch player;
    public Ball ball;
    public PlayerController cube;
    public void triggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Moving to next scene...");
            levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        if (collide.gameObject.CompareTag("lava"))
        {
            StartCoroutine(waitAndKill(2));
        }
        if (collide.gameObject.CompareTag("spikes"))
        {
            print("ree");
            if (player.issphere)
            {
                ball.m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            }
            else
            {
                cube._moveDir = new Vector3(0, 0, cube._moveDir.z);
                cube.Gravity = 0;
            }
            StartCoroutine(waitAndKill(1.5f));
        }
        if (collide.gameObject.CompareTag("tutorialTrigger"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                FindObjectOfType<TutorialScene1>().collisionTriggered(true);
            }else if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                FindObjectOfType<TutorialScene3>().collisionTriggered(true);
            }
            
        }
        if (collide.gameObject.CompareTag("startSpike"))
        {
            collide.gameObject.GetComponent<moveOnlyOnTrigger>().moving = true;
        }
    }
    IEnumerator waitAndKill(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        kill();
        yield return null;
    }
    public void collisionEnter(Collision collide)
    {
        
    }
    void kill()
    {
        Debug.Log("You died");
        levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
