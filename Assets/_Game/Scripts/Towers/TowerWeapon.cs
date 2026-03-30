using System.Collections;
using UnityEngine;

namespace HappyLittleGravekeeper.Towers
{
    public class TowerWeapon : MonoBehaviour
    {
        [SerializeField] private float detectionRange = 10f;
        [SerializeField] private float fireInterval = 1f;

        private Coroutine _fireLoop;

        private void OnEnable()
        {
            _fireLoop = StartCoroutine(FireLoop());
        }

        private void OnDisable()
        {
            if (_fireLoop != null)
                StopCoroutine(_fireLoop);
        }

        private IEnumerator FireLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(fireInterval);
                GameObject target = DetectTargets();
                if (target != null)
                    Fire(target);
            }
        }

        public GameObject DetectTargets()
        {
            // TODO: Add layer mask to restrict detection to Minion and Player layers
            Collider[] hits = Physics.OverlapSphere(transform.position, detectionRange);
            foreach (Collider hit in hits)
            {
                // TODO: Check if collider belongs to a valid target (Minion or Player)
            }
            return null;
        }

        public void Fire(GameObject target)
        {
            // TODO: Instantiate a projectile aimed at target, or apply hitscan damage directly
        }
    }
}
