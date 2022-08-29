using UnityEngine;

namespace TDS.Game.Man
{
    public class ManAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayShoot()
        {
            _animator.SetTrigger("ManShoot");
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat("ManSpeed", speed);
        }
    }
}