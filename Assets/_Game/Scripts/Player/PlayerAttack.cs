using UnityEngine;

namespace HappyLittleGravekeeper.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackDamage = 20f;
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float attackCooldown = 0.5f;

        private float _lastAttackTime;

        private void Update()
        {
            // TODO: Migrate to new Input System when input actions are wired up
            if (!Input.GetMouseButtonDown(0))
                return;

            if (Time.time - _lastAttackTime < attackCooldown)
                return;

            TryAttack();
        }

        private void TryAttack()
        {
            // TODO: OverlapSphere for towers/weak points within attackRange and apply damage
            _lastAttackTime = Time.time;
        }
    }
}
