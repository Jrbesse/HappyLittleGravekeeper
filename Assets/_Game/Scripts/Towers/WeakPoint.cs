using System;
using UnityEngine;

namespace HappyLittleGravekeeper.Towers
{
    public class WeakPoint : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 30f;
        [SerializeField] private float damageMultiplier = 2f;

        private float _currentHealth;

        public event Action OnDestroyed;

        public float DamageMultiplier => damageMultiplier;
        public bool IsAlive => _currentHealth > 0f;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            if (!IsAlive)
                return;

            _currentHealth -= amount * damageMultiplier;

            if (_currentHealth > 0f)
                return;

            _currentHealth = 0f;
            OnDestroyed?.Invoke();
            // TODO: Play destruction VFX before disabling
            gameObject.SetActive(false);
        }
    }
}
