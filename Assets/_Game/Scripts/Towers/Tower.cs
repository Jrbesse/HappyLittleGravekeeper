using System.Collections.Generic;
using UnityEngine;
using HappyLittleGravekeeper.Core;
using HappyLittleGravekeeper.Data;

namespace HappyLittleGravekeeper.Towers
{
    [RequireComponent(typeof(TowerHealth))]
    [RequireComponent(typeof(TowerWeapon))]
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData data;

        private WeakPoint[] _weakPoints;
        private TowerHealth _health;
        private TowerWeapon _weapon;

        public TowerData Data => data;
        public TowerHealth Health => _health;

        private void Awake()
        {
            _health = GetComponent<TowerHealth>();
            _weapon = GetComponent<TowerWeapon>();
            _weakPoints = GetComponentsInChildren<WeakPoint>();
        }

        private void OnEnable()
        {
            if (LevelManager.Instance != null)
                LevelManager.Instance.RegisterTower(this);
        }

        private void OnDisable()
        {
            if (LevelManager.Instance != null)
                LevelManager.Instance.UnregisterTower(this);
        }

        /// <summary>Returns all WeakPoint children that are still alive.</summary>
        public WeakPoint[] GetLivingWeakPoints()
        {
            // TODO: Cache this list and invalidate on WeakPoint.OnDestroyed for performance
            List<WeakPoint> living = new List<WeakPoint>();
            foreach (WeakPoint wp in _weakPoints)
            {
                if (wp != null && wp.IsAlive)
                    living.Add(wp);
            }
            return living.ToArray();
        }
    }
}
