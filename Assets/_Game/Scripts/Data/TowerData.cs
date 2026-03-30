using UnityEngine;

namespace HappyLittleGravekeeper.Data
{
    public enum TowerType
    {
        // TODO: Define tower type categories (e.g., Artillery, Guard, Sniper)
        Generic
    }

    [CreateAssetMenu(menuName = "HLG/Tower Data", fileName = "NewTowerData")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] private string towerName;
        [SerializeField] private float maxHealth;
        [SerializeField] private float detectionRadius;
        [SerializeField] private float fireRate;
        [SerializeField] private float projectileDamage;
        [SerializeField] private bool hasWeakPoints;
        [SerializeField] private float weakPointDamageMultiplier;

        public string TowerName => towerName;
        public float MaxHealth => maxHealth;
        public float DetectionRadius => detectionRadius;
        public float FireRate => fireRate;
        public float ProjectileDamage => projectileDamage;
        public bool HasWeakPoints => hasWeakPoints;
        public float WeakPointDamageMultiplier => weakPointDamageMultiplier;
    }
}
