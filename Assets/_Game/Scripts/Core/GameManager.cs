using System;
using UnityEngine;

namespace HappyLittleGravekeeper.Core
{
    public enum GameState
    {
        MainMenu,
        LevelLoading,
        Playing,
        LevelComplete,
        SkillTree,
        GameOver,
        Credits
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public static event Action OnLevelStart;
        public static event Action OnLevelComplete;
        public static event Action OnPlayerDied;
        public static event Action<int> OnSkillPointsAwarded;

        [SerializeField] private GameState currentState;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ChangeState(GameState newState)
        {
            // TODO: Implement state transition logic and notify listeners
            currentState = newState;
        }

        public void LoadNextLevel()
        {
            // TODO: Increment PlayerProgression.CurrentLevelIndex and load next scene via SceneManager
        }

        public void RestartLevel()
        {
            // TODO: Reload the current active scene
        }

        public void ReturnToMenu()
        {
            // TODO: Load main menu scene by name
        }

        // Raise helpers — other systems call these to fire events through GameManager
        public static void RaiseLevelStart() => OnLevelStart?.Invoke();
        public static void RaiseLevelComplete() => OnLevelComplete?.Invoke();
        public static void RaisePlayerDied() => OnPlayerDied?.Invoke();
        public static void RaiseSkillPointsAwarded(int points) => OnSkillPointsAwarded?.Invoke(points);
    }
}
