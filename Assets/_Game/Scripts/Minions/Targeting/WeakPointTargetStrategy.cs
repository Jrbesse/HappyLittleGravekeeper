using UnityEngine;
using HappyLittleGravekeeper.Towers;

namespace HappyLittleGravekeeper.Minions.Targeting
{
    public class WeakPointTargetStrategy : ITargetingStrategy
    {
        public GameObject FindTarget(Vector3 fromPosition, float range)
        {
            // TODO: Pass a layer mask for Tower layer to avoid redundant GetComponent checks
            Collider[] hits = Physics.OverlapSphere(fromPosition, range);
            GameObject nearestWeakPoint = null;
            float nearestDist = float.MaxValue;

            foreach (Collider hit in hits)
            {
                if (!hit.TryGetComponent<Tower>(out Tower tower))
                    continue;

                WeakPoint[] weakPoints = tower.GetLivingWeakPoints();
                foreach (WeakPoint wp in weakPoints)
                {
                    float dist = Vector3.Distance(fromPosition, wp.transform.position);
                    if (dist >= nearestDist)
                        continue;

                    nearestDist = dist;
                    nearestWeakPoint = wp.gameObject;
                }
            }

            return nearestWeakPoint;
        }
    }
}
