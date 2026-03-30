using UnityEngine;

namespace HappyLittleGravekeeper.CameraSystem
{
    public class IsometricCamera : MonoBehaviour
    {
        private static readonly Vector3 IsometricEuler = new Vector3(35.264f, 45f, 0f);

        [SerializeField] private Transform target;
        [SerializeField] private float followSpeed = 5f;
        [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -10f);

        private void Awake()
        {
            transform.eulerAngles = IsometricEuler;
        }

        private void LateUpdate()
        {
            if (target == null)
                return;

            Vector3 desired = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desired, followSpeed * Time.deltaTime);
        }

        public void SetTarget(Transform t)
        {
            target = t;
        }
    }
}
