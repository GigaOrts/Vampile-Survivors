using UnityEngine;

namespace RogueLike
{
    public class PlayerInput : MonoBehaviour
    {
        private Mover _mover;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        void FixedUpdate()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");
            var direction = new Vector2(horizontalInput, verticalInput);
            
            _mover.Move(direction);
        }
    }
}

