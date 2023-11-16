using Entities;
using UnityEngine;

namespace Objects
{
    public class MedKit: MonoBehaviour
    {
        [SerializeField] private int healAmount;

        private void Heal(Character character)
        {
            character.Heal(healAmount);
        }
    }
}