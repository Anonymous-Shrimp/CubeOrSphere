using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScene3 : MonoBehaviour
{

    public Animator directions;
    public string[] texts;
    public Text popupText;
    int popUpIndex = 1;
    float wait = 2;
    bool collisionTrigger = false;
    public GameObject[] collisions;

    // Start is called before the first frame update
    void Start()
    {
        directions.SetBool("Faded", true);
        collisionTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        popupText.text = texts[popUpIndex];
        if (popUpIndex == 1)
        {
                directions.SetBool("Faded", false);
                popUpIndex++;
            
        }
        else if (popUpIndex == 2)
        {
            if (collisionTrigger)
            {
                Destroy(collisions[0]);
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
        }else if (popUpIndex == 3)
        {
            if (collisionTrigger)
            {
                directions.SetBool("Faded", false);
                Destroy(collisions[1]);
                Destroy(collisions[2]);
                popUpIndex++;
            }
        }else if (popUpIndex == 4)
        {
            if (Input.GetButton("Fire1"))
            {
                directions.SetBool("Faded", true);
                popUpIndex++;
            }
        }
        print(popUpIndex);

    }
    public void collisionTriggered(bool trigger)
    {
        collisionTrigger = trigger;
    }

}
