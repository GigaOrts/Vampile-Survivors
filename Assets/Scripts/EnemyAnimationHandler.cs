using UnityEngine;

namespace RogueLike
{
    public class EnemyAnimationHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void SetDamagedState()
        {
            _animator.SetTrigger("damageTaken");
        }
    }
}
