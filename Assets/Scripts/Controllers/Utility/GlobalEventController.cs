using Entities;
using Support;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers.Utility
{
    public class GlobalEventController: MonoBehaviour
    {
        public static readonly UnityEvent OnEnemyKilled = new UnityEvent();
        public static readonly UnityEvent<Song> OnBattleStarted = new UnityEvent<Song>();
        public static readonly UnityEvent OnPlayerDeath = new UnityEvent();
        public static readonly UnityEvent OnGameStart = new UnityEvent();
        public static readonly UnityEvent OnMainMenu = new UnityEvent();
        public static readonly UnityEvent DealDamageToPlayer = new UnityEvent();
        public static readonly UnityEvent DealDamageToEnemy = new UnityEvent();
        public static readonly UnityEvent<Enemy, Entities.Character> StartBattle = new UnityEvent<Enemy, Entities.Character>();
        public static readonly UnityEvent RestartOpenWorld = new UnityEvent();

        public static void SendOnEnemyKilled()
        {
            OnEnemyKilled.Invoke();
        }
        
        public static void SendOnBattleStarted(Song song)
        {
            OnBattleStarted.Invoke(song);
        }

        public static void SendOnPlayerDeath()
        {
            OnPlayerDeath.Invoke();
        }

        public static void SendOnGameStart()
        {
            OnGameStart.Invoke();
        }

        public static void SendOnMainMenu()
        {
            OnMainMenu.Invoke();
        }

        public static void SendDealDamageToPlayer()
        {
            DealDamageToPlayer.Invoke();
        }
        
        public static void SendDealDamageToEnemy()
        {
            DealDamageToEnemy.Invoke();
        }

        public static void SendStartBattle(Enemy enemy, Entities.Character character)
        {
            StartBattle.Invoke(enemy, character);
        }

        public static void SendRestartOpenWorld()
        {
            RestartOpenWorld.Invoke();
        }
    }
}