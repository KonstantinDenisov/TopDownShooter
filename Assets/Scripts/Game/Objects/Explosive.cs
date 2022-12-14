using System;
using System.Collections;
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
        [SerializeField] private ExplosiveAnimation _explosiveAnimation;
        private float _lifeTime = 1;

        #endregion


        #region Unity Lifecycle

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radiusGizmos);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Explode();
            _explosiveAnimation.PlayExplosive();
        }

        #endregion
        private void Explode()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radiusExplode);

            foreach (Collider2D col in colliders)
            {
                IHealth health = col.GetComponentInParent<IHealth>();
                if (health != null)
                {
                    health.ApplyDamage(_damage);
                }
            }
            StartCoroutine(LifeTimeTimer());
        }
        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
        
    }
}