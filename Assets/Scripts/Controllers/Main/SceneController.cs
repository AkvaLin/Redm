using Controllers.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers.Main
{
    public class SceneController: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            GlobalEventController.OnGameStart.AddListener(GameStart);
        }

        private void EnterBattleScene()
        {
            
        }

        private void EnterOpenWorldScene()
        {
            
        }

        private void GameStart()
        {
            SceneManager.LoadScene("WarehouseMain");
        }
    }
}