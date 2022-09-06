using System;
using System.Collections;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        private Rigidbody2D _rb;

        #endregion


        #region Unity Lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;
            StartCoroutine(LifeTimeTimer());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                EnemyHp enemyHp = other.gameObject.GetComponent<EnemyHp>();
                enemyHp.ApplyDamage(1);
            }
        }

        #endregion


        #region Private Methods

        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }

        #endregion
       
       
    }
}