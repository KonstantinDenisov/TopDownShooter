using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed;
        [SerializeField] private Transform[] _points;
        private int _index;
        private Transform _cashedTransform;
        
        #endregion


        #region Unity Lifecycle

        private void OnEnable()
        {
            _cashedTransform = transform;
        }

        private void FixedUpdate()
        {
            _cashedTransform.position = Vector2.MoveTowards(_cashedTransform.position, 
                _points[_index].position, _speed * Time.fixedDeltaTime);
            if (Vector2.Distance(_cashedTransform.position,_points[_index].position) < 0.1f)
            {
                if (_index > 0)
                {
                    _index = 0;
                }
                else
                {
                    _index = 1;
                }
            }
        }

        #endregion
    }
}
