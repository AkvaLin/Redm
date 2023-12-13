using Controllers.Main;
using Entities;
using UnityEngine;

namespace Controllers.OpenWorld
{
    public class OpenWorldController: MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject canvas;
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameController gc = FindObjectOfType<GameController>();
            Vector3? pos = gc.GetPlayerPosition();
            if (pos != null)
            {
                player.transform.position = pos ?? new Vector3();
            }

            int? id = gc.GetEnemyId();
            if (id != null)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var enemy in enemies)
                {
                    if (enemy.GetComponent<Enemy>().id == id)
                    {
                        Destroy(enemy);
                    }
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canvas.SetActive(true);
            }
        }
    }
}