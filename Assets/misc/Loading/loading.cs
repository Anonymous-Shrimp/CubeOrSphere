using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public Slider slider;
    public GameObject loadingScreen;
    public Animator anim;
    public PauseUI pause;
    

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }


    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        if(!(SceneManager.GetActiveScene().buildIndex == 0))
        {
            pause.boolPause(false);
        }
       


        loadingScreen.SetActive(true);
        Debug.Log("Switch scene to " + sceneIndex);
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        loadingScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait(1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
