using UnityEngine;
using HappyLittleGravekeeper.Minions.Targeting;

namespace HappyLittleGravekeeper.Minions
{
    public class FodderMinion : Minion
    {
        private readonly NearestTargetStrategy _targetingStrategy = new NearestTargetStrategy();

        public override GameObject FindTarget()
        {
            float range = data != null ? data.AttackRange : 10f;
            return _targetingStrategy.FindTarget(transform.position, range);
        }
    }
}
