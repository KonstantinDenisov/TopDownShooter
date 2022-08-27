using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _fireDelay;
        private Transform _cachedTransform;
        private float _delayTimer;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            TickTimer();

            if (CanAttack())
            {
                Attack();
            }
        }

        #endregion


        #region Private Methods

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _delayTimer <= 0;
        }

        private void Attack()
        {
            _playerAnimation.PlayShoot();
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            _delayTimer = _fireDelay;
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }

        #endregion

       
    }
}