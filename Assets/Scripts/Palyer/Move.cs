using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public CharacterController controller;

    public Text Score;

    public float speed = 12f;

    public float JumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;

    private Gravity gravity;

    private Vector3 prevMove;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            Score.text = (Convert.ToInt32(Score.text) + 1).ToString();
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        gravity = new Gravity();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isJump = false;
        bool isCanMove = true;

        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 _move = move * speed * Time.deltaTime;

        if(controller.transform.position.z <= -48f && isCanMove) { isCanMove = false; }
        if(controller.transform.position.z >= 34f && isCanMove) { isCanMove = false; }

        if(controller.transform.position.x >= 26 && isCanMove) { isCanMove = false; }
        if (controller.transform.position.x <= -23 && isCanMove) { isCanMove = false; }

        if (isCanMove)
        {
            controller.Move(_move);

            if (Input.GetButtonDown("Jump")) { isJump = true; };

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
                controller.Move(new Vector3(1.05f, 2.48f, 7.08f));
            }

            prevMove = _move;

            gravity.Math(groundCheck, groundMask, controller, JumpHeight, isJump);
        }

        if(prevMove != Vector3.zero)
        {
            if(controller.transform.position.z <= -48f)
            {
                controller.Move(-prevMove);
            }
            if(controller.transform.position.z >= 34f)
            {
                controller.Move(-prevMove);
            }
            if(controller.transform.position.x >= 26)
            {
                controller.Move(-prevMove);
            }
            if(controller.transform.position.x <= -23)
            {
                controller.Move(-prevMove);
            }
        }

        
    }
}
