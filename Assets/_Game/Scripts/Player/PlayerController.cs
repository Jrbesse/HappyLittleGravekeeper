using UnityEngine;
using UnityEngine.AI;
using HappyLittleGravekeeper.Core;

namespace HappyLittleGravekeeper.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerClickMove))]
    [RequireComponent(typeof(PlayerAttack))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerHealth _health;
        private PlayerClickMove _clickMove;
        private PlayerAttack _attack;

        private void Awake()
        {
            _health = GetComponent<PlayerHealth>();
            _clickMove = GetComponent<PlayerClickMove>();
            _attack = GetComponent<PlayerAttack>();
        }

        private void OnEnable()
        {
            GameManager.OnPlayerDied += HandlePlayerDied;
        }

        private void OnDisable()
        {
            GameManager.OnPlayerDied -= HandlePlayerDied;
        }

        private void HandlePlayerDied()
        {
            // Disable input components; game-over handling proceeds via GameManager state
            _clickMove.enabled = false;
            _attack.enabled = false;
            // TODO: Trigger death animation and transition to GameOver state
        }
    }
}
