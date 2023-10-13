using RogueLike.Core;

namespace RogueLike.Enemy
{
    public class EnemyMover : Mover
    {
        private Player _target;
        private EnemyAI _enemyAI;

        protected override void Awake()
        {
            base.Awake();
            _enemyAI = GetComponent<EnemyAI>();
        }

        private void Start()
        {
            _target = _enemyAI.Target;
        }

        private void FixedUpdate()
        {
            var direction = _target.transform.position - transform.position;
            base.Move(direction);
        }
    }
}