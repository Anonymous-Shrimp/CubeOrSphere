using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endTrigger : MonoBehaviour
{
    public loading levelLoader;
    public squareSwitch player;
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
    }
    IEnumerator waitAndKill(int seconds)
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
