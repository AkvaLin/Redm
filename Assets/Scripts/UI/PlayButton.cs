using System;
using UnityEngine;

namespace UI
{
    public class PlayButton: MonoBehaviour
    {
        public void ButtonClicked()
        {
            GlobalEventController.SendOnGameStart();
        }
    }
}