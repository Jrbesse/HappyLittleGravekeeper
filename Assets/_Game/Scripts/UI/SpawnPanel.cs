using UnityEngine;
using UnityEngine.UI;
using HappyLittleGravekeeper.Data;
using HappyLittleGravekeeper.Minions;

namespace HappyLittleGravekeeper.UI
{
    public class SpawnPanel : MonoBehaviour
    {
        [SerializeField] private MinionSpawner spawner;
        [SerializeField] private Button spawnButtonPrefab;
        [SerializeField] private Transform buttonContainer;

        private void Start()
        {
            BuildButtons();
        }

        private void BuildButtons()
        {
            if (spawner == null || spawnButtonPrefab == null)
                return;

            foreach (MinionData data in spawner.AvailableMinions)
            {
                if (data == null)
                    continue;

                Button btn = Instantiate(spawnButtonPrefab, buttonContainer);
                // TODO: Set button label text and icon from MinionData
                MinionData captured = data;
                btn.onClick.AddListener(() => OnSpawnButtonPressed(captured));
            }
        }

        private void OnSpawnButtonPressed(MinionData data)
        {
            // TODO: Let the player pick a spawn position rather than defaulting to spawner origin
            spawner.SpawnMinion(data, spawner.transform.position);
        }
    }
}
