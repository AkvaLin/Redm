using System;
using UnityEngine;

namespace Controllers.OpenWorld
{
    public class OpenWorldController: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void EnterLevel()
        {
            
        }
    }
}