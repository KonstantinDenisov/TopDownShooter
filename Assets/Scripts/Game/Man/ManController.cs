using System;
using System.Collections;
using UnityEngine;

namespace TDS.Game.Man
{
    public class ManController : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ManAnimation _manAnimation;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        private Transform _cachedTransform;
        [SerializeField] private Transform _follow;
        private Camera _mainCamera;
        private bool _isDeath;
        

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            StartCoroutine(FireRoutine());
        }

        private void Update()
        {
            if (_isDeath)
            {
                return;
            }
            Rotate();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            IEnumerator fireRoutine = FireRoutine();
            if (col.gameObject.CompareTag("PlayerBullet"))
            {
                _manAnimation.PlayDeath(true);
                _isDeath = true;
                if (fireRoutine == null)
                {
                    return;
                }
                StopCoroutine(fireRoutine);
                fireRoutine = null;
            }
        }

        #endregion


        #region Private Methods

        private void Attack()
        {
            _manAnimation.PlayShoot();
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
        }
        
        private void Rotate()
        {
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(_follow.position);
            worldPoint.z = 0f;
            
            Vector3 direction = _follow.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
        
        private IEnumerator FireRoutine()
        {
            while (true)
            {
                Attack();

                yield return new WaitForSeconds(4); 
            }
        }

        #endregion

       
    }
}