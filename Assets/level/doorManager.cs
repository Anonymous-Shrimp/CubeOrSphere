using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public Animator doorAnim;
    public bool pad1;
    public bool pad2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pad1 && !pad2)
        {
            doorAnim.SetBool("Closed", false);
        }
        else
        {
            doorAnim.SetBool("Closed", true);
        }
    }
}
