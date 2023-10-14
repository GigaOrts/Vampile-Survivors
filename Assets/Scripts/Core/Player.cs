using RogueLike.Animations;
using RogueLike.Enemy;
using System.Collections;
using UnityEngine;

namespace RogueLike.Core
{
    public class Player : MonoBehaviour
    {
        private PlayerAnimationHandler _animationHandler;
        private Health _health;
        private bool _isInvincible;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _animationHandler = GetComponent<PlayerAnimationHandler>();
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (_isInvincible)
            {
                return;
            }

            if (collision.gameObject.TryGetComponent(out EnemyAI enemy))
            {
                _health.TakeDamage(enemy.Damage);
                StartCoroutine(nameof(SetInvincibleState));
            }
        }

        private IEnumerator SetInvincibleState()
        {
            _isInvincible = true;
            yield return new WaitForSeconds(1f);
            _isInvincible = false;
        }
    }
}