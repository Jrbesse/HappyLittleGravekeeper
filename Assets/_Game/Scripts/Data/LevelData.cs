using UnityEngine;

namespace HappyLittleGravekeeper.Data
{
    [CreateAssetMenu(menuName = "HLG/Level Data", fileName = "NewLevelData")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private string levelName;
        [SerializeField] private string sceneName;
        [SerializeField] private int skillPointReward;
        [SerializeField] private string storyBlurb;

        public string LevelName => levelName;
        public string SceneName => sceneName;
        public int SkillPointReward => skillPointReward;
        public string StoryBlurb => storyBlurb;
    }
}
