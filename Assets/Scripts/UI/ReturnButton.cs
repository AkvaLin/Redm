using Controllers.Utility;
using UnityEngine;

namespace UI
{
    public class ReturnButton: MonoBehaviour
    {
        public void ButtonClicked()
        {
            GlobalEventController.SendRestartOpenWorld();
        }
    }
}