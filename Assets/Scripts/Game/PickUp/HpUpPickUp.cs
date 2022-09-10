using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.PickUp
{
    public class HpUpPickUp : PickUpBase
    {
        #region Variables

        [SerializeField] private int _hpIncrement;

        #endregion
        protected override void ApplyEffect(Collision2D col)
        {
            PlayerHp playerHp = col.collider.GetComponentInParent<PlayerHp>();
            playerHp.ApplyHeal(_hpIncrement);
            Destroy(gameObject);
        }
    }
}