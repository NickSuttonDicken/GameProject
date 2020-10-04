using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMotion : MonoBehaviour
{
    float speed = 3;
    float rotation = 0f;
    float rotationSpeed = 70;
    float gravity = 7;
    Vector3 moveDirection = Vector3.zero; //X = 0, Y = 0, Z = 0
    CharacterController controller;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //walk forward using Hero's local co-ordinate system
                anim.SetInteger("changeAnim", 1);
                moveDirection = new Vector3(
                                            Mathf.Sin(Mathf.Deg2Rad * rotation),    //X
                                            0,                                      //Y
                                            Mathf.Cos(Mathf.Deg2Rad * rotation)     //Z
                                            );
                moveDirection *= speed; //move at a speed
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                //stop walking forward
                anim.SetInteger("changeAnim", 0);
                moveDirection = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rotation -= Input.GetAxis("Horizontal") + rotationSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rotation += Input.GetAxis("Horizontal") + rotationSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }
            if (Input.GetKey(KeyCode.E)) ;
            {
                anim.SetInteger("changeAnim", 2);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                anim.SetInteger("changeAnim", 0);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
