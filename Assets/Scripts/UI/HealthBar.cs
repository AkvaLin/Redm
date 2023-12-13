using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar: MonoBehaviour
    {
        [SerializeField] private Image healthBar;

        public void UpdateHealth(float fraction)
        {
            healthBar.fillAmount = fraction;
        }
    }
}