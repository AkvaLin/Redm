using Controllers.Utility;
using UnityEngine;

namespace Controllers.Battle
{
    public class BattleController: MonoBehaviour
    {
        private Entities.Character player;
        private Entities.Enemy enemy;

        private void Start()
        {
            GlobalEventController.OnPlayerDeath.AddListener(OnPlayerDeath);
            GlobalEventController.OnEnemyKilled.AddListener(OnEnemyDeath);
            GlobalEventController.DealDamageToEnemy.AddListener(DamageEnemy);
            GlobalEventController.DealDamageToPlayer.AddListener(DamagePlayer);
        }

        private void OnPlayerDeath()
        {
            
        }

        private void OnEnemyDeath()
        {

        }

        private void DamageEnemy()
        {
            enemy.DealDamage(player);
        }

        private void DamagePlayer()
        {
            enemy.DealDamage(player);
        }
    }
}