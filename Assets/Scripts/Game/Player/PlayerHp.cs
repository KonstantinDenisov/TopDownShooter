using System;
using TDS.Game.Objects;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHp : MonoBehaviour, IHealth
    {
        #region Variables

        [SerializeField] private int _startHp;
        [SerializeField] private int _maxHp;
        public int CurrentHp { get; private set; }
        [SerializeField] private int _checkCurrentHp;
        public int MaxHp => _maxHp;
        public event Action<int> OnChanged;

        #endregion


        #region Events

        public event Action<int> OnDecrementHp;

        #endregion


        #region Unity Lefecycle

        private void Awake()
        {
            CurrentHp = _startHp;
            OnDecrementHp?.Invoke(CurrentHp);
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
            OnDecrementHp?.Invoke(CurrentHp);
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyHeal(int heal)
        {
            CurrentHp = Mathf.Min(_maxHp, CurrentHp + heal);
            OnDecrementHp?.Invoke(CurrentHp);
            OnChanged?.Invoke(CurrentHp);
        }

        #endregion
        
    }
}