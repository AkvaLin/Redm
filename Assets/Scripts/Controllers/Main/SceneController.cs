using UnityEngine;

namespace Controllers.Main
{
    public class SceneController: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void EnterBattleScene()
        {
            
        }

        private void EnterOpenWorldScene()
        {
            
        }
    }
}