using UnityEngine;

namespace Controllers.Main
{
    public class GameController: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}