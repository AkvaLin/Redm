using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuButton: MonoBehaviour
    {
        public void ButtonClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}