using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMoveToPlayer : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private TriggerObserver _triggerObserver;

        private Transform _playerTransform;

        #endregion


        #region Unity Lifecycle

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHp>().transform;
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEntered -= OnEntered;
            _triggerObserver.OnExited -= OnExited;
        }

        #endregion


        #region Private Methods

        private void OnEntered(Collider2D col)
        {
            SetTarget(_playerTransform);
        }

        private void OnExited(Collider2D other)
        {
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _enemyMovement.SetTarget(target);
        }

        #endregion
       
    }
}