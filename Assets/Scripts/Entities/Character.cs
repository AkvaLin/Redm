using System;
using Controllers.Utility;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities
{
    public class Character : Entity
    {
        [SerializeField] private string element; // заменить string
        private bool isTriggered = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isTriggered)
            {
                GlobalEventController.SendStartBattle();
            }
        }

        public override void GetDamage(int dmg)
        {
            base.GetDamage(dmg);
            if (hp <= 0)
            {
                GlobalEventController.SendOnPlayerDeath();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                isTriggered = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                isTriggered = false;
            }
        }
    }
}