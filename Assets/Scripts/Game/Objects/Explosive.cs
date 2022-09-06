using System;
using Unity.VisualScripting;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class Explosive : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int _damage;
        [SerializeField] private float _radiusExplode;
        [SerializeField] private float _radiusGizmos;
        
        #endregion


        #region Unity Lifecycle

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radiusGizmos);
        }

        #endregion
        private void Explode()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(Vector3.zero, _radiusExplode);

            foreach (Collider2D col in colliders)
            {
                IHealth health = col.GetComponentInParent<IHealth>();
                if (health != null)
                {
                    health.ApplyDamage(_damage);
                }
            }
        }
        
    }
}