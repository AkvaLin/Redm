using Controllers.Utility;
using JetBrains.Annotations;
using UnityEngine;

namespace Entities
{
    public class TrackCollider: MonoBehaviour
    {
        [SerializeField] private KeyCode button;
        private bool isTriggerd = false;
        [CanBeNull] private Note triggeredObject;

        private void Start()
        {
            GlobalEventController.OnEnemyKilled.AddListener(Stop);
            GlobalEventController.OnPlayerDeath.AddListener(Stop);
        }

        private void Update()
        {
            if (Input.GetKeyDown(button))
            {
                if (isTriggerd)
                {
                    triggeredObject.DestroyNote();
                    triggeredObject = null;
                    isTriggerd = false;
                    GlobalEventController.SendDealDamageToEnemy();
                }
                else
                {
                    GlobalEventController.SendDealDamageToPlayer();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            isTriggerd = true;
            triggeredObject = other.gameObject.GetComponent<Note>();
        }

        private void OnTriggerExit(Collider other)
        {
            isTriggerd = false;
            triggeredObject = null;
        }

        private void Stop()
        {
            isTriggerd = false;
            triggeredObject = null;
        }
    }
}