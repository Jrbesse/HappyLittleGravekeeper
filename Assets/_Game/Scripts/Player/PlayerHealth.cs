using UnityEngine;
using HappyLittleGravekeeper.Core;

namespace HappyLittleGravekeeper.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;

        private float _currentHealth;

        public float MaxHealth => maxHealth;
        public float CurrentHealth => _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            if (_currentHealth <= 0f)
                return;

            _currentHealth -= amount;

            if (_currentHealth > 0f)
                return;

            _currentHealth = 0f;
            GameManager.RaisePlayerDied();
        }
    }
}
