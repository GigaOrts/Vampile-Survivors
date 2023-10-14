using UnityEngine;

namespace RogueLike.Core
{
    public class ExpirienceProvider : MonoBehaviour
    {
        [SerializeField] private int _expirienceGain;
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.Died += OnDeath;
        }

        private void OnDisable()
        {
            _health.Died += OnDeath;
        }

        private void OnDeath()
        {
            FindObjectOfType<Player>().GetComponent<Level>().IncreaseExpirience(_expirienceGain);
        }
    }
}

