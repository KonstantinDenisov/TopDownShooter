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
        public int MaxHp => _maxHp;

        #endregion


        #region Ivents

        public event Action<int> OnChanged;

        #endregion


        #region Unity Lefecycle

        private void Awake()
        {
            CurrentHp = _startHp;
            OnChanged?.Invoke(CurrentHp);
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