using UnityEngine;
using HappyLittleGravekeeper.Data;
using HappyLittleGravekeeper.Towers;

namespace HappyLittleGravekeeper.Minions.Targeting
{
    public class PriorityTargetStrategy : ITargetingStrategy
    {
        private readonly TowerType _preferredType;

        public PriorityTargetStrategy(TowerType preferredType)
        {
            _preferredType = preferredType;
        }

        public GameObject FindTarget(Vector3 fromPosition, float range)
        {
            // TODO: Pass a layer mask for Tower layer to avoid redundant GetComponent checks
            Collider[] hits = Physics.OverlapSphere(fromPosition, range);
            GameObject best = null;
            float bestScore = float.MinValue;

            foreach (Collider hit in hits)
            {
                if (!hit.TryGetComponent<Tower>(out Tower tower))
                    continue;

                float score = ScoreTower(tower, fromPosition);
                if (score <= bestScore)
                    continue;

                bestScore = score;
                best = hit.gameObject;
            }

            return best;
        }

        private float ScoreTower(Tower tower, Vector3 fromPosition)
        {
            // TODO: Add type priority bonus when tower.TowerType matches _preferredType
            // TODO: Factor in inverse health percentage to prefer weakened towers
            return 0f;
        }
    }
}
