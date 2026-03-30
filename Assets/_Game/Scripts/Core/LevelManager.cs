using System.Collections.Generic;
using UnityEngine;
using HappyLittleGravekeeper.Towers;

namespace HappyLittleGravekeeper.Core
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        private readonly List<Tower> _registeredTowers = new List<Tower>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void RegisterTower(Tower tower)
        {
            if (!_registeredTowers.Contains(tower))
                _registeredTowers.Add(tower);
        }

        public void UnregisterTower(Tower tower)
        {
            _registeredTowers.Remove(tower);

            if (_registeredTowers.Count == 0)
                GameManager.RaiseLevelComplete();
        }

        public int GetRemainingTowerCount()
        {
            return _registeredTowers.Count;
        }
    }
}
