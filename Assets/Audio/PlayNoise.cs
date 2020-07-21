using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNoise : MonoBehaviour
{
    public AudioManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void playNoise(string noise)
    {
        manager.Play(noise);
    }
}
