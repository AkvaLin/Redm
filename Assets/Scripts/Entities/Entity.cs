using UnityEngine;

namespace Entities
{
    public abstract class Entity: MonoBehaviour
    {
        [SerializeField] private protected int hp;
        [SerializeField] private int maxHp;
        [SerializeField] private protected int damage;
        [SerializeField] private protected float speed;

        private protected bool isInFight;

        public virtual void GetDamage(int dmg)
        {
            hp -= dmg;
        }

        public void DealDamage(Entity entity)
        {
            entity.GetDamage(damage);
        }

        public void Heal(int healAmount)
        {
            hp += healAmount;
            if (hp > maxHp)
            {
                hp = maxHp;
            }
        }

        public float GetFriction()
        {
            return  (float)hp / (float)maxHp;
        }
    }
}