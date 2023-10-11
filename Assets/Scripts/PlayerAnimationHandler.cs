using System.Collections;
using UnityEngine;

namespace RogueLike
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private Animator _animator;
        private Vector3 positiveScaleX = new(1, 1, 1);
        private Vector3 negativeScaleX = new(-1, 1, 1);

        public bool IsFlippedLeft { get; private set; }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void FlipSprite(float velocityX)
        {
            if (velocityX < 0)
            {
                transform.localScale = negativeScaleX;
                IsFlippedLeft = true;
            }
            else if (velocityX > 0)
            {
                transform.localScale = positiveScaleX;
                IsFlippedLeft = false;
            }
        }

        public IEnumerator SetAttackStateAsync()
        {
            var animationDelay = 0.1f;

            _animator.SetTrigger("attack");
            yield return new WaitForSeconds(animationDelay);
        }

        public void SetMovementState(Vector2 velocity)
        {
            if (velocity is { x: 0, y: 0 })
            {
                _animator.SetTrigger("idle");
            }
            else
            {
                _animator.SetTrigger("run");
            }
        }
    }
}
