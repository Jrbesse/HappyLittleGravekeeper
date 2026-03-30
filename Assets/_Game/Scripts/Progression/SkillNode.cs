using HappyLittleGravekeeper.Data;

namespace HappyLittleGravekeeper.Progression
{
    /// <summary>
    /// Wraps a SkillData asset with runtime state used by the skill tree and UI.
    /// </summary>
    public class SkillNode
    {
        public SkillData Data { get; private set; }
        public bool IsUnlocked { get; private set; }
        public bool IsAvailable { get; private set; }

        public SkillNode(SkillData data)
        {
            Data = data;
        }

        public void SetUnlocked(bool value)
        {
            IsUnlocked = value;
        }

        public void SetAvailable(bool value)
        {
            IsAvailable = value;
        }
    }
}
