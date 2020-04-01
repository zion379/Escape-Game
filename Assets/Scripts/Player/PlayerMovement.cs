using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverPhoenixGames.Escape.PlayerMove
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;

        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        Vector3 velocity;
        bool isGrounded;

        private void Start()
        {
            controller = this.gameObject.GetComponent<CharacterController>();

            if (groundCheck == null)
            {
                if (GameObject.Find("GroundCheck"))
                {
                    groundCheck = GameObject.Find("GroundCheck").transform;
                }
                else
                {
                    Debug.LogError("can not find Ground check transform for player.");
                }
            }
        }

        void Update()
        {
            Jump();
            Movement();
        }

        private void Movement()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            // Apply movemeent to character controller.
            controller.Move(move * speed * Time.deltaTime);
        }

        private void Jump()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime); // multiplied by time twice to  be squared.
        }

    }
}
