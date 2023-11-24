using System;
using Controllers.Utility;
using UnityEngine;
using DG.Tweening;

namespace Entities
{
    public class Note: MonoBehaviour
    {
        private Transform triggerEnter = new RectTransform();
        private Transform triggerExit = new RectTransform();

        private void Start()
        {
            GlobalEventController.OnEnemyKilled.AddListener(Stop);
            GlobalEventController.OnPlayerDeath.AddListener(Stop);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                GlobalEventController.SendDealDamageToPlayer();
                DestroyNote();
            }
        }

        public void StartMotion(float speed)
        {
            transform.DOMoveX(40, speed);
        }

        public void DestroyNote()
        {
            transform.DOComplete();
            Destroy(gameObject);
        }

        public void Stop()
        {
            DestroyNote();
        }
    }
}