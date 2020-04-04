using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SilverPhoenixGames.Escape.UI;
using DG.Tweening;

namespace SilverPhoenixGames.Escape.Interactable
{
    public class SlidingDoor : MonoBehaviour
    {
        public enum OpenDirection { x, y, z }
        public OpenDirection direction = OpenDirection.y;
        [Tooltip("This is distance the door will open")]
        public float openDistance = 3f;
        [Tooltip("This is the speed the door will open.")]
        public float openSpeed = 2f;
        [Tooltip("The body of the door")]
        public Transform doorBody;
        [SerializeField]
        private bool Snapping = false;

        bool open = false;

        Vector3 defaultDoorPosition;

        private void Start()
        {
            if (doorBody)
            {
                defaultDoorPosition = doorBody.localPosition;
            }
        }

        public void TriggerDoor()
        {
            if (!open)
            {
                Open();
                Debug.Log("Opening");
            }
            else
            {
                Close();
                Debug.Log("Closing");
            }
        }

        void Open()
        {
            OpenDoorPosition(openDistance);
            open = true;
        }

        void Close()
        {
            CloseDoorPosition();
            open = false;
        }

        public void OpenDoorPosition(float offset)
        {
            switch (direction)
            {
                case OpenDirection.x:
                    doorBody.DOLocalMove(new Vector3(defaultDoorPosition.x + offset, defaultDoorPosition.y, defaultDoorPosition.z), openSpeed, Snapping);
                    break;
                case OpenDirection.y:
                    doorBody.DOLocalMove(new Vector3(defaultDoorPosition.x, defaultDoorPosition.y + offset, defaultDoorPosition.z), openSpeed, Snapping);
                    break;
                case OpenDirection.z:
                    doorBody.DOLocalMove(new Vector3(defaultDoorPosition.x, defaultDoorPosition.y, defaultDoorPosition.z + offset), openSpeed, Snapping);
                    break;
            }
        }

        public void CloseDoorPosition()
        {
            switch (direction)
            {
                case OpenDirection.x:
                    doorBody.DOLocalMove(defaultDoorPosition, openSpeed, Snapping);
                    break;
                case OpenDirection.y:
                    doorBody.DOLocalMove(defaultDoorPosition, openSpeed, Snapping);
                    break;
                case OpenDirection.z:
                    doorBody.DOLocalMove(defaultDoorPosition, openSpeed, Snapping);
                    break;
            }
        }
    }
}
