using System;
using Controllers.Utility;
using Entities;
using JetBrains.Annotations;
using UnityEngine;

namespace Controllers.Main
{
    public class GameController: MonoBehaviour
    {
        [CanBeNull] private Enemy selectedEnemy;
        [CanBeNull] private Entities.Character character;
        private Vector3? playerPosition;
        private int? enemyIdToDelete;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            GlobalEventController.StartBattle.AddListener(StartBattle);
        }

        private void StartBattle(Enemy enemy, Entities.Character character)
        {
            this.selectedEnemy = enemy;
            this.character = character;
        }

        public Enemy GetEnemy()
        {
            return selectedEnemy;
        }

        public Entities.Character GetCharacter()
        {
            return character;
        }
        
        public void ResetPlayerPosition()
        {
            playerPosition = null;
        }

        public void SetPlayerPosition(Transform position)
        {
            Vector3 vector = position.position;
            playerPosition = new Vector3(vector.x, vector.y, vector.z);
        }

        public Vector3? GetPlayerPosition()
        {
            return playerPosition;
        }

        public void ResetEnemyId()
        {
            enemyIdToDelete = null;
        }
        
        public void SetEnemyId(int id)
        {
            enemyIdToDelete = id;
        }

        public int? GetEnemyId()
        {
            return enemyIdToDelete;
        }
    }
}