using UnityEngine;
using UnityEngine.UI;
using HappyLittleGravekeeper.Core;

namespace HappyLittleGravekeeper.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            bool hasSave = SaveSystem.Load() != null;
            if (continueButton != null)
                continueButton.interactable = hasSave;

            newGameButton?.onClick.AddListener(OnNewGame);
            continueButton?.onClick.AddListener(OnContinue);
            quitButton?.onClick.AddListener(OnQuit);
        }

        private void OnNewGame()
        {
            // TODO: Reset PlayerProgression to defaults and load the first level
        }

        private void OnContinue()
        {
            // TODO: Load saved PlayerProgression and load scene at CurrentLevelIndex
        }

        private void OnQuit()
        {
            Application.Quit();
        }
    }
}
