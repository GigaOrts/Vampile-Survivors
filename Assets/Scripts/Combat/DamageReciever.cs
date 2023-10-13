using System.Collections;
using RogueLike.Animations;
using RogueLike.Enemy;
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
            _health -= damage;
            _animationHandler.SetDamagedState();

            if (IsAlive == false)
            {
                Die();
            }
        }

        public void PushBack(Vector3 fromPosition, float force)
        {
            var pushDirection = transform.position - fromPosition;

            StartCoroutine(nameof(PauseMove));

            _rigidbody.AddForce(pushDirection.normalized * force, ForceMode2D.Impulse);
        }

        private void Die()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;

            var deathDelay = 0.15f;
            Destroy(gameObject, deathDelay);
        }

        private IEnumerator PauseMove()
        {
            var mover = GetComponent<EnemyMover>();
            mover.enabled = false;

            var minVelocity = 0.5f;
            while (Mathf.Abs(_rigidbody.velocity.x) > minVelocity ||
                   Mathf.Abs(_rigidbody.velocity.y) > minVelocity)
            {
                yield return null;
            }

            mover.enabled = true;
        }
    }
}

