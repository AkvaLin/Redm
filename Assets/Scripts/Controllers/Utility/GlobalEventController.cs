using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Controllers.Utility
{
    public class GlobalEventController: MonoBehaviour
    {
        public static readonly UnityEvent OnEnemyKilled = new UnityEvent();
        public static readonly UnityEvent OnBattleStarted = new UnityEvent();
        public static readonly UnityEvent OnBattleEnded = new UnityEvent();
        public static readonly UnityEvent OnPlayerDeath = new UnityEvent();
        public static readonly UnityEvent<Scene> OnNewLocationEntered = new UnityEvent<Scene>();

        public static void SendOnEnemyKilled()
        {
            OnEnemyKilled.Invoke();
        }
        
        public static void SendOnBattleStarted()
        {
            OnBattleStarted.Invoke();
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
    }
}