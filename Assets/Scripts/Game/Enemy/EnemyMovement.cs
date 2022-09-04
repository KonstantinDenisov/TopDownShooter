﻿using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed = 4;
        [SerializeField] private Transform _target;

        private Rigidbody2D _rb;
        private Transform _cachedTransform;
        private bool IsTargetValid() =>
            _target != null;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void OnDisable()
        {
            SetVelocity(Vector2.zero);
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
                return;

            MoveToTarget();
            RotateToTarget();
        }

        #endregion


        #region Public Methods

        public void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
                SetVelocity(Vector2.zero);
        }

        #endregion


        #region Private Methods

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            SetVelocity(direction * _speed);
        }

        private void RotateToTarget()
        {
            Vector3 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }

        private void SetVelocity(Vector2 velocity) =>
            _rb.velocity = velocity;


        #endregion



    }
}