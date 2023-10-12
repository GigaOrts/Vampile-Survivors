using UnityEngine;

namespace RogueLike.Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage  = 1f;
        [SerializeField] private float _cooldown = 1f;
        [SerializeField] private float _damageAreaRadius = 2.7f;
        [SerializeField] private float _pushForce = 80f;

        public float Damage => _damage;
        public float PushForce => _pushForce;
        public float Cooldown => _cooldown;
        public float DamageAreaRadius => _damageAreaRadius;

        public virtual void Attack(DamageReciever target)
        {
            target.TakeDamage(Damage);
        }
    }
}