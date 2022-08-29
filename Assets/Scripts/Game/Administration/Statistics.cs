using System;
using UnityEngine;

namespace TDS.Game.Administration
{
    public class Statistics : SingletonMonoBehaviour<Statistics>
    {
        #region Variables
    
        public int Points;
        [SerializeField] public int HPCount = 4;

        #endregion


        #region Events

        public event Action<int> OnHpChanged;

        #endregion


        #region Public Methods
        
        public void ResetStatistics()
        {
            HPCount = 4;
            Points = 0;
            OnHpChanged?.Invoke(HPCount);
        }

        public void DecrementHp()
        {
            HPCount--;
            OnHpChanged?.Invoke(HPCount);
        }

        #endregion
    }
}