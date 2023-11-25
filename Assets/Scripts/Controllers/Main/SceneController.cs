using System;
using Controllers.Utility;
using Entities;
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
            GlobalEventController.StartBattle.AddListener(EnterBattleScene);
        }

        private void EnterBattleScene(Enemy enemy, Entities.Character character)
        {
            SceneManager.LoadScene("BattleScene");
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