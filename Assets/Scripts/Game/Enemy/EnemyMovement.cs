using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private float _speed = 4;

        protected float Speed => _speed;

        public abstract void SetTarget(Transform target);

        protected void SetAnimationSpeed(float speed) =>
            _animation.SetSpeed(speed);
    }
}