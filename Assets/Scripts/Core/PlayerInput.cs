using UnityEngine;

namespace RogueLike.Core
{
    [RequireComponent(typeof(Mover))]
    public class PlayerInput : MonoBehaviour
    {
        private Mover _mover;

        private float _horizontalInput;
        private float _verticalInput;
        private Vector2 _direction;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
            _direction = new Vector2(_horizontalInput, _verticalInput);
        }

        private void FixedUpdate()
        {
            _mover.Move(_direction);
        }
    }
}

