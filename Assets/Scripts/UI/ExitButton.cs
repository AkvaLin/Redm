using UnityEngine;

namespace UI
{
    public class ExitButton: MonoBehaviour
    {
        public void ButtonClicked()
        {
            Application.Quit();
        }
    }
}