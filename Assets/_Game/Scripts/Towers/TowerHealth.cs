using System;
using UnityEngine;

namespace HappyLittleGravekeeper.Towers
{
    public class TowerHealth : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;

        private float _currentHealth;

        public event Action OnDeath;

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
            OnDeath?.Invoke();
            // TODO: Trigger death animation/VFX before disabling
            gameObject.SetActive(false);
        }

        public float GetHealthPercent()
        {
            return maxHealth > 0f ? _currentHealth / maxHealth : 0f;
        }
    }
}
