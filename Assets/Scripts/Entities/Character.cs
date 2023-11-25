using System;
using Controllers.Utility;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities
{
    public class Character : Entity
    {
        [SerializeField] private string element; // заменить string
        private bool isTriggered = false;
        [CanBeNull] private Enemy enemy;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isTriggered)
            {
                GlobalEventController.SendStartBattle(enemy, this);
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
                enemy = other.gameObject.GetComponent<Enemy>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                isTriggered = false;
                enemy = null;
            }
        }
    }
}