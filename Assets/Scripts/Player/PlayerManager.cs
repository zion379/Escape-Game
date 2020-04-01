using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilverPhoenixGames.Escape.PlayerMove;
using SilverPhoenixGames.Escape.Interactable;

namespace SilverPhoenixGames.Escape
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        [Tooltip("player move Speed")]
        public float movementSpeed = 12f;
        [Tooltip ("player desired Jump Height")]
        public float jumpHeight = 3f;
        [Tooltip("Sensitivity of player camera movement")]
        public float mouseSensitivity = 200f;
        [Tooltip("max detection distance. for object pickup")]
        public float grabDistance = 3f;
        [Tooltip("Throwing Force")]
        public float throwForce = 200f;

        private PlayerMovement playerMovement;
        private PlayerLook playerLook;
        private SelectionManager selectionManager;

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();

            // check if Componenet exist in children.
            if (this.gameObject.GetComponentInChildren<PlayerLook>())
            {
                playerLook = this.gameObject.GetComponentInChildren<PlayerLook>();
            }
            else { Debug.LogError("Player Look Script is missing from child object. Attach Player Look script to child Camera."); }

            if (this.gameObject.GetComponentInChildren<SelectionManager>())
            {
                selectionManager = this.gameObject.GetComponentInChildren<SelectionManager>();
            }
            else { Debug.LogError("SelectionManager is Missing from Child. Attach Selection Manager to Grab Transform on player."); }

            //Assign values to scripts.
            playerMovement.speed = movementSpeed;
            playerMovement.jumpHeight = jumpHeight;
            playerLook.mouseSensitivity = mouseSensitivity;
            selectionManager.maxDetectionDistance = grabDistance;
            selectionManager.throwForce = throwForce;
        }

    }
}
