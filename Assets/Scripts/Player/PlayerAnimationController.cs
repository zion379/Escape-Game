using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverPhoenixGames.Escape.Animation
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator anim;

        private bool isCrouching = false;

        private void Start()
        {
            if (anim == null)
            {
                if (GetComponent<Animator>())
                {
                    anim = GetComponent<Animator>();
                }
                else
                {
                    Debug.LogError($"There is no Animator component on {this.name}");
                }
            }
        }

        private void Update()
        {
            float verticalAxis = Input.GetAxis("Vertical");
            float horizontalAxis = Input.GetAxis("Horizontal");

            Jump(verticalAxis);
            Crouch();
            Move(verticalAxis, horizontalAxis);
        }

        void Move(float Vertical, float Horizontal)
        {
            anim.SetFloat("VelY", Vertical * 10);
            anim.SetFloat("VelX", Horizontal * 10);
        }

        void Jump(float translation)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // check if player is moving
                if (translation != 0 && !isCrouching)
                {
                    // moving
                    anim.SetTrigger("RunJump");
                }
                else
                {
                    // not moving
                    anim.SetTrigger("Jump");
                }
            }
        }

        void Crouch()
        {
            if (Input.GetButtonDown("crouch"))
            {
                if (isCrouching)
                {
                    isCrouching = false;
                }
                else
                {
                    isCrouching = true;
                }
                anim.SetBool("Crouch", isCrouching);
            }
        }
    }
}

