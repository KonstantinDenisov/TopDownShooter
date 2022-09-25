using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayShoot()
        {
            _animator.SetTrigger("EnemyShoot");
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat("EnemySpeed", speed);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger("EnemyDeath");
        }

        public void PlayAttack()
        {
            
        }
    }
}