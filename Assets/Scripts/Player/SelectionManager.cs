using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SilverPhoenixGames.Escape.Interactable
{
    public class SelectionManager : MonoBehaviour
    {
        public float maxDetectionDistance = 2.5f;

        [SerializeField]
        private Image selector;

        private Transform item;

        [SerializeField]
        private bool isHolding;

        public float throwForce = 10f;

        private IInteractable currentTarget;



        private void Start()
        {
            if (selector == null)
            {
                if (GameObject.Find("BaseCanvas").transform.Find("Selector"))
                {
                    selector = GameObject.Find("BaseCanvas").transform.Find("Selector").GetComponent<Image>();
                }
                else
                { Debug.LogError("Cannot find Selector Image."); }
            }

            isHolding = false;
        }

        private void Update()
        {
            // intereact
            if (Input.GetButtonDown("use"))
            {
                if (currentTarget != null)
                {
                    currentTarget.OnInteract();
                }
            }

            // drop
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentTarget != null)
                {
                    // grab and drop
                    if (!isHolding)
                    {
                        Grab();
                    }
                    else
                    {
                        Drop();
                    }
                }
            }

            //throw
            if (Input.GetButtonDown("Fire2"))
            {
                if (currentTarget != null)
                {
                    Throw();
                    
                }
            }

            DetectInteractable();


            if (isHolding)
            {
                currentTarget.Hold();
            }
        }

        void Grab()
        {
            currentTarget.Grab(this.transform);
            isHolding = true;
        }

        void Drop()
        {
            currentTarget.Drop();
            isHolding = false;
        }

        void Throw()
        {
            currentTarget.Throw(this.transform.forward * throwForce);
            isHolding = false;
        }

        void DetectInteractable()
        {
            Transform camPosition = Camera.main.transform;
            RaycastHit hit;
            if (Physics.Raycast(camPosition.position, camPosition.forward, out hit, maxDetectionDistance))
            {

                IInteractable interactable = hit.transform.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    if (interactable == currentTarget)
                    {
                        return;
                    }
                    else if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                    }
                    selector.color = Color.red;
                }
            }
            else
            {
                // set Selector color grey
                selector.color = Color.grey;

                // end On hover && reset on hover
                if (currentTarget != null && !isHolding)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }
            }
        }
    }
}

