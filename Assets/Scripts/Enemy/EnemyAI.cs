using RogueLike.Core;
using UnityEngine;
// TODO партиклы при смерти
// TODO выпадение опыта/золота

namespace RogueLike.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        public Player Target { get; private set; }
        public int Damage { get; private set; } = 1;

        private void Start()
        {
            Target = FindObjectOfType<Player>();
        }
    }
}
