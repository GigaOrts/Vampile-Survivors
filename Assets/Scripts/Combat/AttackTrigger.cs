using System.Collections;
using RogueLike.Animations;
using UnityEngine;

namespace RogueLike.Combat
{
    public class AttackTrigger : MonoBehaviour
    {
        private Weapon _weapon;
        private PlayerAnimationHandler _animationHandler;

        private void Awake()
        {
            _weapon = GetComponent<Weapon>();
            _animationHandler = GetComponentInParent<PlayerAnimationHandler>();
        }

        private void Start()
        {
            StartCoroutine(nameof(Attack));
        }

        private IEnumerator Attack()
        {
            var delay = _weapon.Cooldown;
            
            while (true)
            {
                yield return _animationHandler.SetAttackStateAsync();
                
                AttackAllInRange();
                yield return new WaitForSeconds(delay);
            }
        }

        private void AttackAllInRange()
        {
            var origin = new Vector2(transform.position.x, transform.position.y);

            var circleDirection = _animationHandler.IsFlippedLeft ? Vector2.left : Vector2.right;

            var circleCastAll = Physics2D.CircleCastAll(origin + circleDirection,
                _weapon.DamageAreaRadius, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Damageable"));

            foreach (var hit2D in circleCastAll)
            {
                var target = hit2D.collider.gameObject.GetComponent<DamageReciever>();

                _weapon.Attack(target);
                target.PushBack(_weapon.transform.position, _weapon.PushForce);
            }
        }
    }
}
