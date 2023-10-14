using RogueLike.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private float _changeStep = 0.5f;

        private Slider _slider;
        private Coroutine _coroutine;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = _health.MaxValue;
            _slider.value = _slider.maxValue;
        }

        private void OnEnable()
        {
            _health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int targetHealthValue)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeHealth(targetHealthValue));
        }

        private IEnumerator ChangeHealth(int targetValue)
        {
            while (_slider.value != targetValue)
            {
                _slider.value = Mathf.MoveTowards(_health.CurrentValue, targetValue, _changeStep * Time.deltaTime);
                yield return null;
            }
        }
    }
}

