using UnityEngine;
using HappyLittleGravekeeper.Minions.Targeting;

namespace HappyLittleGravekeeper.Minions
{
    public class HeroMinion : Minion
    {
        private readonly WeakPointTargetStrategy _targetingStrategy = new WeakPointTargetStrategy();

        public override GameObject FindTarget()
        {
            float range = data != null ? data.AttackRange : 10f;
            return _targetingStrategy.FindTarget(transform.position, range);
        }
    }
}
