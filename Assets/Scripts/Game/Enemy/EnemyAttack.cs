using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _damage = 1;
        [SerializeField] private float _attackDelay;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _radius;
        private float _radiusGizmos;

        private float _delayTimer;

        #endregion


        #region Unity Lifecycle

        private void Start()
        {
            _radiusGizmos = _radius;
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radiusGizmos);
        }

        private void Update()
        {
            TickTimer();
        }

        #endregion


        #region Public Methods

        public void Attack()
        {
            if (CanAttack())
                AttackInternal();
        }

        #endregion


        #region Private Methods

        private void TickTimer() =>
            _delayTimer -= Time.deltaTime;

        private bool CanAttack() =>
            _delayTimer <= 0;

        private void AttackInternal()
        {
            _delayTimer = _attackDelay;
            Collider2D col = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);
            if (col == null)
                return;

            PlayerHp playerHp = col.GetComponentInParent<PlayerHp>();
            if (playerHp != null)
                playerHp.ApplyDamage(_damage);
        }

        #endregion
        
    }
}