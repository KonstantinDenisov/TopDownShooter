using System;

namespace TDS.Game.Objects
{
    public interface IHealth
    {

        #region Variables

        int CurrentHp { get; }
        int MaxHp { get; }

        #endregion


        #region Events

        event Action<int> OnChanged;

        #endregion


        #region Methods

        void ApplyDamage(int damage);
        void ApplyHeal(int heal);

        #endregion
        
    }
}

