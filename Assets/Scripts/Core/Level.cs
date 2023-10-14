using System;
using UnityEngine;

namespace RogueLike.Core
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _currentValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private int _increaseStep;
        [SerializeField] private int _currentLevel;

        public int CurrentValue => _currentValue;
        public int MaxValue => _maxValue;
        public bool IsLevelUp => _currentValue >= _maxValue;

        public event Action<int> ValueChanged;
        public event Action LevelUp;

        public void IncreaseExpirience(int value)
        {
            _currentValue += value;

            ValueChanged?.Invoke(_currentValue);

            if (IsLevelUp)
            {
                UpgradeLevel();
                LevelUp?.Invoke();
            }
        }

        public void UpgradeLevel()
        {
            _currentValue = 0;
            _maxValue+= _increaseStep;
            _currentLevel++;
        }
    }
}
