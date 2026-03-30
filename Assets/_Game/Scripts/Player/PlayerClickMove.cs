using UnityEngine;
using UnityEngine.AI;

namespace HappyLittleGravekeeper.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerClickMove : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayerMask;

        private NavMeshAgent _agent;
        private Camera _mainCamera;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            // TODO: Migrate to new Input System when input actions are wired up
            if (!Input.GetMouseButtonDown(1))
                return;

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, groundLayerMask))
                return;

            _agent.SetDestination(hit.point);
        }
    }
}
