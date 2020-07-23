using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnlyOnTrigger : MonoBehaviour
{
    public CinemachineDollyCart cart;
    public float speed = 3.5f;
    public bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        cart.m_Speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            cart.m_Speed = speed;
        }
    }
}
