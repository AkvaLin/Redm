using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Entities
{
    public class TrackCollider: MonoBehaviour
    {
        [SerializeField] private KeyCode button;
        private bool isTriggerd = false;
        [CanBeNull] private GameObject triggeredObject;

        private void Update()
        {
            if (Input.GetKeyDown(button))
            {
                if (isTriggerd)
                {
                    triggeredObject.GetComponent<Note>().DestroyNote();
                    triggeredObject = null;
                    isTriggerd = false;
                }
                else
                {
                    print("Урон");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            isTriggerd = true;
            triggeredObject = other.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            isTriggerd = false;
            triggeredObject = null;
        }
    }
}