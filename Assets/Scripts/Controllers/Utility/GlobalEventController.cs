using Support;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Controllers.Utility
{
    public class GlobalEventController: MonoBehaviour
    {
        public static readonly UnityEvent OnEnemyKilled = new UnityEvent();
        public static readonly UnityEvent<Song> OnBattleStarted = new UnityEvent<Song>();
        public static readonly UnityEvent OnBattleEnded = new UnityEvent();
        public static readonly UnityEvent OnPlayerDeath = new UnityEvent();
        public static readonly UnityEvent<Scene> OnNewLocationEntered = new UnityEvent<Scene>();
        public static readonly UnityEvent OnGameStart = new UnityEvent();
        public static readonly UnityEvent DealDamageToPlayer = new UnityEvent();
        public static readonly UnityEvent DealDamageToEnemy = new UnityEvent();
        public static readonly UnityEvent StartBattle = new UnityEvent();

        public static void SendOnEnemyKilled()
        {
            OnEnemyKilled.Invoke();
        }
        
        public static void SendOnBattleStarted(Song song)
        {
            OnBattleStarted.Invoke(song);
        }
        
        public static void SendOnBattleEnded()
        {
            OnBattleEnded.Invoke();
        }
        
        public static void SendOnPlayerDeath()
        {
            OnPlayerDeath.Invoke();
        }
        
        public static void SendOnNewLocationEntered(Scene scene)
        {
            OnNewLocationEntered.Invoke(scene);
        }

        public static void SendOnGameStart()
        {
            OnGameStart.Invoke();
        }

        public static void SendDealDamageToPlayer()
        {
            DealDamageToPlayer.Invoke();
        }
        
        public static void SendDealDamageToEnemy()
        {
            DealDamageToEnemy.Invoke();
        }

        public static void SendStartBattle()
        {
            StartBattle.Invoke();
        }
    }
}