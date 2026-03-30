using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HappyLittleGravekeeper.Progression;

namespace HappyLittleGravekeeper.UI
{
    public class SkillTreeUI : MonoBehaviour
    {
        [SerializeField] private SkillTree skillTree;
        [SerializeField] private Button skillNodeButtonPrefab;
        [SerializeField] private Transform nodeContainer;

        private readonly List<Button> _nodeButtons = new List<Button>();

        public void Render()
        {
            ClearButtons();

            if (skillTree == null)
                return;

            foreach (SkillNode node in skillTree.Nodes)
            {
                Button btn = Instantiate(skillNodeButtonPrefab, nodeContainer);
                // TODO: Set button label, icon, and visual state (locked / available / unlocked)
                btn.interactable = node.IsAvailable;
                SkillNode captured = node;
                btn.onClick.AddListener(() => OnNodeButtonPressed(captured));
                _nodeButtons.Add(btn);
            }
        }

        private void OnNodeButtonPressed(SkillNode node)
        {
            if (node.IsUnlocked || !node.IsAvailable)
                return;

            skillTree.Unlock(node.Data);
            Render();
        }

        private void ClearButtons()
        {
            foreach (Button btn in _nodeButtons)
            {
                if (btn != null)
                    Destroy(btn.gameObject);
            }
            _nodeButtons.Clear();
        }
    }
}
