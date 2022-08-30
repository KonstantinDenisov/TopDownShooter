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
            Rotate();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("PlayerBullet"))
            {
                _manAnimation.PlayDeath(true);
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