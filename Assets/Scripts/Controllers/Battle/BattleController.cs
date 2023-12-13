using Controllers.Main;
using Controllers.Utility;
using UnityEngine;

namespace Controllers.Battle
{
    public class BattleController: MonoBehaviour
    {
        private Entities.Character player;
        private Entities.Enemy enemy;
        [SerializeField] private GameObject container;
        [SerializeField] private GameObject winMenu;
        [SerializeField] private GameObject defeatMenu;

        private void Start()
        {
            GlobalEventController.OnPlayerDeath.AddListener(OnPlayerDeath);
            GlobalEventController.OnEnemyKilled.AddListener(OnEnemyDeath);
            GlobalEventController.DealDamageToEnemy.AddListener(DamageEnemy);
            GlobalEventController.DealDamageToPlayer.AddListener(DamagePlayer);
            GameController gc = GameObject.FindObjectOfType<GameController>();
            enemy = gc.GetEnemy();
            player = gc.GetCharacter();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnPlayerDeath()
        {
            container.SetActive(true);
            defeatMenu.SetActive(true);
            GameController gc = FindObjectOfType<GameController>();
            gc.ResetPlayerPosition();
            gc.ResetEnemyId();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void OnEnemyDeath()
        {
            container.SetActive(true);
            winMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void DamageEnemy()
        { 
            player.DealDamage(enemy);
        }

        private void DamagePlayer()
        {
            enemy.DealDamage(player);
        }
    }
}