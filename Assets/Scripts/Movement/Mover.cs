using RogueLike.Animations;
using UnityEngine;

namespace RogueLike
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 200f;

        private Rigidbody2D _rigidbody;
        private AnimationHandler _animationHandler;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animationHandler = GetComponent<AnimationHandler>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.velocity = Time.deltaTime * _speed * direction.normalized;

            _animationHandler.FlipSprite(_rigidbody.velocity.x);
            _animationHandler.SetMovementState(_rigidbody.velocity);
        }
    }
}
