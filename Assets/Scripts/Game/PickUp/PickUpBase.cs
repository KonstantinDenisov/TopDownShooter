using TDS.Game.Administration;
using UnityEngine;

namespace TDS.Game.PickUp
{
    public abstract class PickUpBase : MonoBehaviour
    {
        #region Unity Lifecycle

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag(Tags.Player))
                return;

            ApplyEffect(col);
        
            Destroy(gameObject);
        }

        #endregion


        #region Protected Methods

        protected abstract void ApplyEffect(Collision2D col);

        #endregion
    }
}