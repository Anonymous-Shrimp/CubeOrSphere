using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transferCameraAnimation : MonoBehaviour
{
    public TutorialScene4 scene;
    public bool controllable = false;
    public GameObject mainCamera;

    private void Start()
    {
        mainCamera = scene.mainCamera;
    }
    // Update is called once per frame
    void Update()
    {
        scene.controllable = controllable;
    }
}
