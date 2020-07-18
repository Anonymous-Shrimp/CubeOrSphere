using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endTrigger : MonoBehaviour
{
    public loading levelLoader;
    public void triggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Moving to next scene...");
            levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }
    public void collisionEnter(Collision collide)
    {
        
    }
}
