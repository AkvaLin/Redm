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
    }
}