using UnityEngine;
using UnityEngine.AI;
using HappyLittleGravekeeper.Data;

namespace HappyLittleGravekeeper.Minions
{
    public enum MinionState
    {
        Idle,
        Moving,
        Attacking,
        Dead
    }

    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class Minion : MonoBehaviour
    {
        [SerializeField] protected MinionData data;

        protected float currentHealth;
        protected NavMeshAgent agent;
        protected MinionState state;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        protected virtual void Start()
        {
            if (data != null)
            {
                currentHealth = data.MaxHealth;
                agent.speed = data.MoveSpeed;
            }
        }

        /// <summary>Returns the best current target GameObject, or null if none in range.</summary>
        public abstract GameObject FindTarget();

        /// <summary>Called when this minion's health reaches zero. Override to add death effects.</summary>
        public virtual void OnDeath()
        {
            // TODO: Play death VFX, notify spawner/pool manager
        }

        /// <summary>Called when the NavMeshAgent arrives at the target destination.</summary>
        public virtual void OnReachTarget()
        {
            // TODO: Transition to Attacking state and begin attack sequence
        }

        public void TakeDamage(float amount)
        {
            if (state == MinionState.Dead)
                return;

            currentHealth -= amount;
            if (currentHealth <= 0f)
                Die();
        }

        public void Die()
        {
            if (state == MinionState.Dead)
                return;

            state = MinionState.Dead;
            OnDeath();
            // TODO: Return to object pool instead of destroying
            Destroy(gameObject);
        }

        public void MoveTowards(Vector3 position)
        {
            if (agent == null || state == MinionState.Dead)
                return;

            state = MinionState.Moving;
            agent.SetDestination(position);
        }
    }
}
