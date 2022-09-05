using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMeleeAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayAttack()
        {
            _animator.SetTrigger("AttackEnemyMelee");
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat("SpeedEnemyMelee", speed);
        }

        public void PlayDeath()
        {
            _animator.SetTrigger("DeathEnemyMelee");
        }
        
        public void StopAttack()
        {
            _animator.SetTrigger("StopAttackEnemyMelee");
        }
        
    }
}