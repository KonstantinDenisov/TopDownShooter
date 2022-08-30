using TDS.Game.Administration;
using UnityEngine;

namespace TDS.Game.PickUp
{
    public class HpUpPickUp : PickUpBase
    {
        protected override void ApplyEffect(Collision2D col)
        {
            Statistics.Instance.IncrementHp();
        }
    }
}