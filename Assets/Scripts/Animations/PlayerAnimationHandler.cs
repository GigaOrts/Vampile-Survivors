using System.Collections;
using UnityEngine;

namespace RogueLike.Animations
{
    public class PlayerAnimationHandler : AnimationHandler
    {
        private readonly float _attackAnimationDelay = 0.1f;
        private readonly string _attackTrigger = "attack";
        
        public IEnumerator SetAttackStateAsync()
        {
            Animator.SetTrigger(_attackTrigger);
            yield return new WaitForSeconds(_attackAnimationDelay);
        }
    }
}
