using System.Collections;
using UnityEngine;

namespace RogueLike.Core
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 5f;
        [SerializeField] private int _additionalDelayPerWave = 1;
        [SerializeField] private int _countOfEnemies = 3;
        [SerializeField] private int _enemiesPerWave = 2;
        [SerializeField] private float _radius = 10f;

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

            if (_elapsedTime > _spawnDelay)
            {
                _elapsedTime = 0;
                UpdateWave();
                SetAngleStep();
                StartCoroutine(nameof(SpawnCircleEnemies));
            }
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position;
        }

        private void UpdateWave()
        {
            _countOfEnemies += _enemiesPerWave;
            _spawnDelay += _additionalDelayPerWave;
        }

        private void SetAngleStep()
        {
            _angleStep = maxDegree / _countOfEnemies;
        }

        private IEnumerator SpawnCircleEnemies()
        {
            for (int i = 0; i < _countOfEnemies; i++)
            {
                var newEnemy = Instantiate(_enemy);
                newEnemy.transform.position = new Vector3(
                    transform.position.x + _radius * Mathf.Cos(_angleStep * (i + 1) * Mathf.Deg2Rad),
                    transform.position.y + _radius * Mathf.Sin(_angleStep * (i + 1) * Mathf.Deg2Rad), 0);

                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
