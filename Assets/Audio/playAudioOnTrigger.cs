using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioOnTrigger : MonoBehaviour
{
    public AudioManager manager;
    public bool canPlay;
    public string clipName;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlay)
        {
            manager.Play(clipName);
            canPlay = false;
        }
    }
}
