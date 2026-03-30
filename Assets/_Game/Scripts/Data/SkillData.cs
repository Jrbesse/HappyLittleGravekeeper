using UnityEngine;

namespace HappyLittleGravekeeper.Data
{
    public enum SkillEffectType
    {
        MinionHealth,
        MinionSpeed,
        MinionDamage,
        PlayerHealth,
        PlayerDamage,
        PlayerSpeed,
        ResourceRegen,
        SpawnCooldown
    }

    [CreateAssetMenu(menuName = "HLG/Skill Data", fileName = "NewSkillData")]
    public class SkillData : ScriptableObject
    {
        [SerializeField] private string skillId;
        [SerializeField] private string displayName;
        [SerializeField] private string description;
        [SerializeField] private int cost;
        [SerializeField] private string[] prerequisiteIds;
        [SerializeField] private SkillEffectType effectType;
        [SerializeField] private float magnitude;
        [SerializeField] private Sprite icon;

        public string SkillId => skillId;
        public string DisplayName => displayName;
        public string Description => description;
        public int Cost => cost;
        public string[] PrerequisiteIds => prerequisiteIds;
        public SkillEffectType EffectType => effectType;
        public float Magnitude => magnitude;
        public Sprite Icon => icon;
    }
}
