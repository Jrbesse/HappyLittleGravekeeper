using UnityEngine;

namespace HappyLittleGravekeeper.Minions.Targeting
{
    public interface ITargetingStrategy
    {
        GameObject FindTarget(Vector3 fromPosition, float range);
    }
}
