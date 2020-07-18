using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public bool cursorLock = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = !cursorLock;
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
