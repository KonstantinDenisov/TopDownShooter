using UnityEngine;

namespace TDS.Game.Objects
{
    public class ExplosiveAnimation : MonoBehaviour

    {
    [SerializeField] private Animator _animator;

    public void PlayExplosive()
    {
        _animator.SetTrigger("Explosive");
    }
    }
}