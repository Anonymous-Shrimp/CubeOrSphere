using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public bool canPause = false;
    public bool LockCursor = true;
    public bool isPaused = false;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        cursorLock(LockCursor);

    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    pauseUI.SetActive(true);
                    Time.timeScale = 0;
                    cursorLock(false);
                }
                else
                {
                    pauseUI.SetActive(false);
                    Time.timeScale = 1;
                    cursorLock(true);
                }
            }
        }
        else
        {
            isPaused = false;
        }
    }

    void cursorLock(bool locke)
    {
        Cursor.visible = !locke;
        if (locke)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
    public void boolPause(bool pauser)
    {
        isPaused = pauser;
        if (isPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            cursorLock(false);
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            cursorLock(true);
        }
    }
}
