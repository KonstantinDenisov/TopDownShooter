using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class TriggerObserver : MonoBehaviour
    {
        #region Variables

        [SerializeField] private CircleCollider2D _circleCollider2D;
        private float _radiusGizmos;

        #endregion
        
        #region Events
        
        public event Action<Collider2D> OnEntered; 
        public event Action<Collider2D> OnStayed;
        public event Action<Collider2D> OnExited; 
        
        #endregion


        #region Unity Lifecycle

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radiusGizmos);
        }

        #endregion

        #region Private Methods
        
        private void OnTriggerEnter2D(Collider2D col) =>
            OnEntered?.Invoke(col);

        private void OnTriggerExit2D(Collider2D other) =>
            OnExited?.Invoke(other);
        
        #endregion


        
    }
}