﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToSceneNoLoad(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
    public void quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }


}
