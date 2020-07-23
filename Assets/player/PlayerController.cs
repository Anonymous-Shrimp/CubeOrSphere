using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public CharacterController _characterController;

    public float Speed = 5.0f;

    public float RotationSpeed = 240.0f;

   

    public float jumpSpeed = 10;
    public float jumpPadSpeed = 30;


    [HideInInspector]
    public bool canMove = true;
    public bool canJump = true;
    public float Gravity = 20.0f;

    public Vector3 _moveDir = Vector3.zero;


    // Use this for initialization
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

            // Get Input for axis
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");


            // Calculate the forward vector

            Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

            if (move.magnitude > 1f) move.Normalize();



            // Calculate the rotation for the player
            move = transform.InverseTransformDirection(move);

            // Get Euler angles
            float turnAmount = Mathf.Atan2(move.x, move.z);

            transform.Rotate(0, turnAmount * RotationSpeed * Time.deltaTime, 0);

            if (_characterController.isGrounded)
            {
                //_animator.SetBool("run", move.magnitude> 0);

                _moveDir = transform.forward * move.magnitude;

                _moveDir *= Speed;
                if (canJump)
                {
                    if (Input.GetButton("Jump"))
                    {
                        _moveDir.y = jumpSpeed;
                    }
                }
            }

            _moveDir.y -= Gravity * Time.deltaTime;

            _characterController.Move(_moveDir * Time.deltaTime);
        }
    }

}
