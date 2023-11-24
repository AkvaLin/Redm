using Controllers.Utility;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities
{
    public class Character : Entity
    {
        [SerializeField] private string element; // заменить string

        public override void GetDamage(int dmg)
        {
            base.GetDamage(dmg);
            if (hp <= 0)
            {
                GlobalEventController.SendOnPlayerDeath();
            }
        }
    }
}