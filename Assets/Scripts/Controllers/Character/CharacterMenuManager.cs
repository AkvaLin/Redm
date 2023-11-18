using System;
using TMPro;
using UnityEngine;

namespace Controllers.Character
{
    public class CharacterMenuManager : MonoBehaviour
    {
        private int _numberDeaths;
        private int _numberEnemiesKilled;
        
        public string GetNumberDeaths() => _numberDeaths.ToString();
        public string GetNumberEnemiesKilled() => _numberEnemiesKilled.ToString();
    }
}