using UnityEngine;

namespace Controllers.OpenWorld
{
    public class OpenWorldController: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void EnterLevel()
        {
            
        }
    }
}