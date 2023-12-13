using UnityEngine;

namespace UI
{
    public class ContinueButton: MonoBehaviour
    {
        [SerializeField] private GameObject canvas;

        public void ButtonClicked()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvas.SetActive(false);
        }
    }
}