using System;
using TDS.Game.Objects;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyHp : MonoBehaviour, IHealth
    {
        #region Variables

        [SerializeField] private int _startHp;
        [SerializeField] private int _maxHp;
        [SerializeField] private int _checkCurrentHp;

        public event Action<int> OnChanged;

        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;
        

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            CurrentHp = _startHp;
            OnChanged?.Invoke(CurrentHp);
        }

        private void Update()
        {
            _checkCurrentHp = CurrentHp;
        }

        #endregion


        #region Public Methods

        public void ApplyDamage(int damage)
        {
            CurrentHp = Mathf.Max(0, CurrentHp - damage);
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyHeal(int heal)
        {
            CurrentHp = Mathf.Min(_maxHp, CurrentHp + heal);
            OnChanged?.Invoke(CurrentHp);
        }

        #endregion
       
    }
}