using System;
using System.Collections.Generic;

namespace HappyLittleGravekeeper.Progression
{
    [Serializable]
    public class PlayerProgression
    {
        public int CurrentLevelIndex;
        public int TotalSkillPoints;
        public int SpentSkillPoints;
        public List<string> UnlockedSkillIds = new List<string>();

        public bool IsSkillUnlocked(string skillId)
        {
            return UnlockedSkillIds.Contains(skillId);
        }
    }
}
