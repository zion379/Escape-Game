using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SilverPhoenixGames.Escape.Interactable
{
    public interface IInteractable
    {
        float MaxRange { get; }

        void OnStartHover();
        void OnInteract();
        void OnEndHover();
        void Grab(Transform tempParent);
        void Drop();
        void Throw(Vector3 Force);
        void Hold();
    }
}
