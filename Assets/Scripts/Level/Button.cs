using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SilverPhoenixGames.Escape.UI;

namespace SilverPhoenixGames.Escape.Interactable
{
    public class Button : MonoBehaviour, IInteractable
    {
        private void Awake()
        {
            if (ButtonPress == null)
                ButtonPress = new UnityEvent();
        }

        public UnityEvent ButtonPress;

        float IInteractable.MaxRange { get { return maxRange; } }
        [SerializeField]
        private float maxRange = 4;

        string IInteractable.ObjectName { get { return objectName; } }
        [SerializeField]
        private string objectName = "";

        bool IInteractable.CanInteract { get { return canInteract; } }
        [SerializeField]
        private bool canInteract = true;



        public void Drop()
        {
            // will not use
        }

        public void Grab(Transform tempParent)
        {
            // will not use
        }

        public void Hold()
        {
            // will not use
        }

        public void OnEndHover()
        {
            SelectorInfo.ClearText();
        }

        public void OnInteract()
        {
            ButtonPress.Invoke();
        }

        public void OnStartHover()
        {
            SelectorInfo.ChangeText(objectName);
        }

        public void Throw(Vector3 Force)
        {
            // will not use
        }

    }
}
