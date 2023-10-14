using RogueLike.Enemy;
using System.Collections;
using UnityEngine;

namespace RogueLike.Core
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 5f;
        [SerializeField] private int _delayPerWave = 1;
        [SerializeField] private int _countOfEnemies = 3;
        [SerializeField] private int _enemiesPerWave = 2;
        [SerializeField] private float _radius = 10f;
        
        [SerializeField] private int _totalEnemies = 50;
        [SerializeField] private int _maxTotalEnemies = 50;

        const float maxDegree = 360;

        private GameObject _enemy;
        private Player _player;
        private float _elapsedTime;
        private float _angleStep;

        private void Awake()
        {
            _enemy = Resources.Load<GameObject>("Enemy Variant");
            _player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            SetAngleStep();
            StartCoroutine(nameof(SpawnCircleEnemies));
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            _totalEnemies = FindObjectsOfType<EnemyAI>().Length;

            if (_elapsedTime > _spawnDelay && _totalEnemies < _maxTotalEnemies)
            {
                _elapsedTime = 0;
                UpdateWave();
                SetAngleStep();
                StartCoroutine(nameof(SpawnCircleEnemies));
            }
        }

        private void LateUpdate()
        {
            if (_player != null)
                transform.position = _player.transform.position;
        }

        private void UpdateWave()
        {
            _countOfEnemies += _enemiesPerWave;
            _spawnDelay += _delayPerWave;
        }

        private void SetAngleStep()
        {
            _angleStep = maxDegree / _countOfEnemies;
        }

        private IEnumerator SpawnCircleEnemies()
        {
            if (_player == null)
                yield break;

            for (int i = 0; i < _countOfEnemies; i++)
            {
                if (_totalEnemies >= _maxTotalEnemies)
                    yield break;

                var newEnemy = Instantiate(_enemy);
                newEnemy.transform.position = new Vector3(
                    transform.position.x + _radius * Mathf.Cos(_angleStep * (i + 1) * Mathf.Deg2Rad),
                    transform.position.y + _radius * Mathf.Sin(_angleStep * (i + 1) * Mathf.Deg2Rad), 0);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
