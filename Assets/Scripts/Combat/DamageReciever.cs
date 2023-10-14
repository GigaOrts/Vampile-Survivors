using System.Collections;
using RogueLike.Enemy;
using UnityEngine;

namespace RogueLike.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DamageReciever : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void PushBack(Vector3 fromPosition, float force)
        {
            var pushDirection = transform.position - fromPosition;

            StartCoroutine(nameof(PauseMove));

            _rigidbody.AddForce(pushDirection.normalized * force, ForceMode2D.Impulse);
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

