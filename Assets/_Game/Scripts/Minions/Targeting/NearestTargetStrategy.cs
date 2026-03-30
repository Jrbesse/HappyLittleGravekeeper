using UnityEngine;
using HappyLittleGravekeeper.Towers;

namespace HappyLittleGravekeeper.Minions.Targeting
{
    public class NearestTargetStrategy : ITargetingStrategy
    {
        public GameObject FindTarget(Vector3 fromPosition, float range)
        {
            // TODO: Pass a layer mask for Tower layer to avoid redundant GetComponent checks
            Collider[] hits = Physics.OverlapSphere(fromPosition, range);
            GameObject nearest = null;
            float nearestDist = float.MaxValue;

            foreach (Collider hit in hits)
            {
                if (!hit.TryGetComponent<Tower>(out _))
                    continue;

                float dist = Vector3.Distance(fromPosition, hit.transform.position);
                if (dist >= nearestDist)
                    continue;

                nearestDist = dist;
                nearest = hit.gameObject;
            }

            return nearest;
        }
    }
}
