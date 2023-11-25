using Controllers.Utility;
using UnityEngine;
using UnityEngine.UIElements;

namespace Entities
{
    public class Enemy: Entity
    {
        [SerializeField] private string[] elements; // заменить string
        [SerializeField] private AudioClip music;
        [SerializeField] private Position[] locationPositions;
        
        private bool isTriggered = false;
        
        public override void GetDamage(int dmg)
        {
            base.GetDamage(dmg);
            if (hp <= 0)
            {
                GlobalEventController.SendOnEnemyKilled();
            }
        }

        private void Roam()
        {
            // Линейное передвижение из точки в точку
        }

        private void Aggression()
        {
            // Движение на игрока и попытка его ударить для начала битвы
        }

        private void FixedUpdate()
        {
            if (isTriggered & !isInFight)
            {
                Aggression();
            }
        }
    }
}