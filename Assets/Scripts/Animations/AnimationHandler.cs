using RogueLike.Core;
using UnityEngine;

namespace RogueLike.Animations
{
    [RequireComponent(typeof(Health))]
    public class AnimationHandler : MonoBehaviour
    {
        protected Animator Animator;
        private Health _health;
        private readonly Vector3 _xPositiveScale = new(1, 1, 1);
        private readonly Vector3 _xNegativeScale = new(-1, 1, 1);

        private readonly string _damageTakenTrigger = "damageTaken";
        private readonly string _idleTrigger = "idle";
        private readonly string _runTrigger = "run";

        public bool IsFlippedLeft { get; private set; }

        private void OnEnable()
        {
            _health.DamageTaken += SetDamagedState;
        }

        private void OnDisable()
        {
            _health.DamageTaken -= SetDamagedState;
        }

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
            Animator = GetComponentInChildren<Animator>();
        }

        public void FlipSprite(float xVelocity)
        {
            switch (xVelocity)
            {
                case < 0:
                    transform.localScale = _xNegativeScale;
                    IsFlippedLeft = true;
                    break;
                case > 0:
                    transform.localScale = _xPositiveScale;
                    IsFlippedLeft = false;
                    break;
            }
        }

        public void SetMovementState(Vector2 velocity)
        {
            Animator.SetTrigger(velocity == Vector2.zero ? _idleTrigger : _runTrigger);
        }

        public void SetDamagedState()
        {
            Animator.SetTrigger(_damageTakenTrigger);
        }
    }
}