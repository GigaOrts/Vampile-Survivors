using UnityEngine;

namespace RogueLike
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;
        private PlayerAnimationHandler _playerAnimationHandler;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.velocity = Time.deltaTime * _speed * direction.normalized;

            _playerAnimationHandler.FlipSprite(_rigidbody.velocity.x);
            _playerAnimationHandler.SetMovementState(_rigidbody.velocity);
        }
    }
}
