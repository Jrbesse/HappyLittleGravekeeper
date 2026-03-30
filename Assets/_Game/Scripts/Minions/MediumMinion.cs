using UnityEngine;
using HappyLittleGravekeeper.Data;
using HappyLittleGravekeeper.Minions.Targeting;

namespace HappyLittleGravekeeper.Minions
{
    public class MediumMinion : Minion
    {
        public TowerType preferredTargetType;

        private PriorityTargetStrategy _targetingStrategy;

        protected override void Awake()
        {
            base.Awake();
            _targetingStrategy = new PriorityTargetStrategy(preferredTargetType);
        }

        public override GameObject FindTarget()
        {
            float range = data != null ? data.AttackRange : 10f;
            return _targetingStrategy.FindTarget(transform.position, range);
        }
    }
}
