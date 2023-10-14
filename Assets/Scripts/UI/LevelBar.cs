using RogueLike.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RogueLike.UI
{
    public class LevelBar : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private float _changeStep = 1f;

        private Slider _slider;
        private Coroutine _coroutine;

        private void Awake()
        {
            _slider = GetComponent<Slider>(); 
            OnLevelUp();
        }

        private void OnEnable()
        {
            _level.ValueChanged += OnLevelChanged;
            _level.LevelUp += OnLevelUp;
        }

        private void OnDisable()
        {
            _level.ValueChanged -= OnLevelChanged;
            _level.LevelUp -= OnLevelUp;
        }

        private void OnLevelChanged(int targetValue)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeLevel(targetValue));
        }

        private IEnumerator ChangeLevel(int targetValue)
        {
            while (_slider.value != targetValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _changeStep * Time.deltaTime);
                yield return null;
            }
        }

        private void OnLevelUp()
        {
            _slider.value = _slider.minValue;
            _slider.maxValue = _level.MaxValue;
        }
    }
}
