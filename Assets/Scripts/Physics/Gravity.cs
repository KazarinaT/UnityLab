using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravity = -9.81f;

    public float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    public void Math(Transform groundCheck, LayerMask groundMask, CharacterController controller, float JumpHeight, bool isJump)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isJump && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
