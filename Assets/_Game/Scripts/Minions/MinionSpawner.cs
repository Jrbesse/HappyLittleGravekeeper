using UnityEngine;
using HappyLittleGravekeeper.Data;

namespace HappyLittleGravekeeper.Minions
{
    public class MinionSpawner : MonoBehaviour
    {
        [SerializeField] private MinionData[] availableMinions;
        [SerializeField] private float maxResources = 100f;
        [SerializeField] private float resourceRegenRate = 5f;

        private float _currentResources;

        public float CurrentResources => _currentResources;
        public float MaxResources => maxResources;
        public MinionData[] AvailableMinions => availableMinions;

        private void Start()
        {
            _currentResources = maxResources;
        }

        private void Update()
        {
            _currentResources = Mathf.Min(_currentResources + resourceRegenRate * Time.deltaTime, maxResources);
        }

        public void SpawnMinion(MinionData data, Vector3 position)
        {
            if (data == null || data.Prefab == null)
                return;

            int cost = GetSpawnCost(data);
            if (_currentResources < cost)
                return;

            _currentResources -= cost;
            // TODO: Use an object pool instead of Instantiate for performance
            Instantiate(data.Prefab, position, Quaternion.identity);
        }

        public int GetSpawnCost(MinionData data)
        {
            if (data == null)
                return 0;

            return data.SpawnCost;
        }
    }
}
