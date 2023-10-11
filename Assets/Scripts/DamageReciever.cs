using UnityEngine;

namespace RogueLike
{
    public class DamageReciever : MonoBehaviour
    {
        [SerializeField] private float _health;
        
        private EnemyAnimationHandler _animationHandler;
        private Rigidbody2D _rigidbody;

        public bool IsAlive => Health > 0;

        public float Health
        {
            get => _health;
            protected set => _health = Mathf.Max(value, 0);
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animationHandler = GetComponent<EnemyAnimationHandler>();
        }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
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

