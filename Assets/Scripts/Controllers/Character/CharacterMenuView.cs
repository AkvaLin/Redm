using TMPro;
using UnityEngine;

namespace Controllers.Character
{
    public class CharacterMenuView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI numberEnemiesKilledValueText;
        [SerializeField] private TextMeshProUGUI numberDeathsValueText;
        [SerializeField] private CharacterMenuManager characterMenuManager;

        public void UpdateData()
        {
            Debug.Log("Обновленные данных статистики.");
            numberDeathsValueText.text = characterMenuManager.GetNumberDeaths();
            numberEnemiesKilledValueText.text = characterMenuManager.GetNumberEnemiesKilled();
        }
    }
}