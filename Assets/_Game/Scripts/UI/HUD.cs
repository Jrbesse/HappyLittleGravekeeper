using UnityEngine;
using UnityEngine.UI;
using HappyLittleGravekeeper.Core;

namespace HappyLittleGravekeeper.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Text resourceText;
        [SerializeField] private Text towerCountText;
        [SerializeField] private Slider playerHealthBar;

        private void OnEnable()
        {
            GameManager.OnLevelStart += HandleLevelStart;
            GameManager.OnLevelComplete += HandleLevelComplete;
            GameManager.OnPlayerDied += HandlePlayerDied;
        }

        private void OnDisable()
        {
            GameManager.OnLevelStart -= HandleLevelStart;
            GameManager.OnLevelComplete -= HandleLevelComplete;
            GameManager.OnPlayerDied -= HandlePlayerDied;
        }

        public void UpdateResourceDisplay(int current, int max)
        {
            if (resourceText != null)
                resourceText.text = $"{current} / {max}";
        }

        public void UpdateTowerCount(int remaining)
        {
            if (towerCountText != null)
                towerCountText.text = $"Towers: {remaining}";
        }

        private void HandleLevelStart()
        {
            // TODO: Reset HUD elements for new level
        }

        private void HandleLevelComplete()
        {
            // TODO: Show level-complete overlay
        }

        private void HandlePlayerDied()
        {
            // TODO: Show game-over overlay
        }
    }
}
