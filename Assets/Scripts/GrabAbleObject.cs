using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilverPhoenixGames.Escape.UI;

namespace SilverPhoenixGames.Escape.Interactable
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrabAbleObject : MonoBehaviour, IInteractable
    {
        public float MaxRange { get { return maxRange; } }
        private float maxRange = 4f;

        private Rigidbody rb;

        public string objectName = "";

        private void Start()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
        }

        public void OnEndHover()
        {
            SelectorInfo.ClearText();
        }

        public void OnInteract()
        {
        }

        public void OnStartHover()
        {
            SelectorInfo.ChangeText(objectName);
        }

        public void Grab(Transform tempParent)
        {
            rb.useGravity = false;
            rb.detectCollisions = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.SetParent(tempParent);
        }

        public void Drop()
        {
            this.transform.SetParent(null);
            rb.useGravity = true;
        }

        public void Throw(Vector3 Force)
        {
            this.transform.SetParent(null);
            rb.useGravity = true;
            rb.AddForce(Force);
        }

        public void Hold()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
