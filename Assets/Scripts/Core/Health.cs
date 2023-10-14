using System;
using UnityEngine;

namespace RogueLike.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxValue;
        
        private int _currentValue;

        public int CurrentValue => _currentValue;

        public int MaxValue => _maxValue;
        public bool IsAlive => CurrentValue > 0;

        public event Action<int> ValueChanged;
        public event Action DamageTaken;
        public event Action Died;

        private void Awake()
        {
            _currentValue = MaxValue;
        }

        public void TakeDamage(int damage)
        {
            _currentValue -= damage;

            ValueChanged?.Invoke(_currentValue);
            DamageTaken?.Invoke();

            if (IsAlive == false)
            {
                Died?.Invoke();
                Die();
            }
        }

        public void Die()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;

            var deathDelay = 0.15f;
            Destroy(gameObject, deathDelay);
        }
    }
}

