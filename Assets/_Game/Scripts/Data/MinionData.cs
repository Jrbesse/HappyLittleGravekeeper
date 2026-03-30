using UnityEngine;

namespace HappyLittleGravekeeper.Data
{
    public enum MinionType
    {
        Fodder,
        Medium,
        Hero
    }

    [CreateAssetMenu(menuName = "HLG/Minion Data", fileName = "NewMinionData")]
    public class MinionData : ScriptableObject
    {
        [SerializeField] private string minionName;
        [SerializeField] private MinionType type;
        [SerializeField] private float maxHealth;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float attackDamage;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackCooldown;
        [SerializeField] private int spawnCost;
        [SerializeField] private GameObject prefab;

        public string MinionName => minionName;
        public MinionType Type => type;
        public float MaxHealth => maxHealth;
        public float MoveSpeed => moveSpeed;
        public float AttackDamage => attackDamage;
        public float AttackRange => attackRange;
        public float AttackCooldown => attackCooldown;
        public int SpawnCost => spawnCost;
        public GameObject Prefab => prefab;
    }
}
