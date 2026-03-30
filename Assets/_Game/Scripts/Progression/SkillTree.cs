using System.Collections.Generic;
using UnityEngine;
using HappyLittleGravekeeper.Data;

namespace HappyLittleGravekeeper.Progression
{
    public class SkillTree : MonoBehaviour
    {
        [SerializeField] private SkillData[] allSkills;

        private readonly List<SkillNode> _nodes = new List<SkillNode>();
        private PlayerProgression _progression;

        public IReadOnlyList<SkillNode> Nodes => _nodes;

        public void Initialize(PlayerProgression progression)
        {
            _progression = progression;
            _nodes.Clear();

            foreach (SkillData skill in allSkills)
            {
                if (skill == null)
                    continue;

                SkillNode node = new SkillNode(skill);
                node.SetUnlocked(progression.IsSkillUnlocked(skill.SkillId));
                _nodes.Add(node);
            }

            RefreshAvailability();
        }

        public bool CanUnlock(SkillData skill)
        {
            if (skill == null || _progression == null)
                return false;

            if (_progression.IsSkillUnlocked(skill.SkillId))
                return false;

            int availablePoints = _progression.TotalSkillPoints - _progression.SpentSkillPoints;
            if (availablePoints < skill.Cost)
                return false;

            foreach (string prereqId in skill.PrerequisiteIds)
            {
                if (!_progression.IsSkillUnlocked(prereqId))
                    return false;
            }

            return true;
        }

        public void Unlock(SkillData skill)
        {
            if (!CanUnlock(skill))
                return;

            _progression.UnlockedSkillIds.Add(skill.SkillId);
            _progression.SpentSkillPoints += skill.Cost;

            SkillNode node = _nodes.Find(n => n.Data == skill);
            node?.SetUnlocked(true);
            RefreshAvailability();
        }

        public void ApplyAllUnlockedSkills()
        {
            // TODO: Iterate all unlocked skill nodes and apply their SkillEffectType + magnitude
            //       to the relevant game systems (MinionSpawner, PlayerHealth, etc.)
        }

        private void RefreshAvailability()
        {
            foreach (SkillNode node in _nodes)
                node.SetAvailable(CanUnlock(node.Data));
        }
    }
}
