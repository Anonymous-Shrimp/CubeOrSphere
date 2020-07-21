using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    public SceneManage manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.goToSceneNoLoad(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
