using RogueLike.Animations;
using UnityEngine;

namespace RogueLike.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DamageReciever : MonoBehaviour
    {
        [SerializeField] private float _health;
        
        private AnimationHandler _animationHandler;
        private Rigidbody2D _rigidbody;

        public bool IsAlive => _health > 0;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animationHandler = GetComponent<AnimationHandler>();
        }

        public void TakeDamage(float damage)
        {
            _health -= Mathf.Max(_health - damage, 0);
            _animationHandler.SetDamagedState();

            if (IsAlive == false)
            {
                Die();
            }
        }

        public void PushBack(Vector3 fromPosition, float force)
        {
            var pushDirection = transform.position - fromPosition;

            _rigidbody.AddForce(pushDirection.normalized * force, ForceMode2D.Impulse);
        }

        private void Die()
        {

        }
    }
}

