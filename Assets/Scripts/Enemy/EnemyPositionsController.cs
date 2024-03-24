using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyPositionsController : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPositions;
        [SerializeField] private List<Position> _attackPositions;

        private readonly List<Position> _occupiedPositions = new();
        
        public Position GetRandomAttackPosition()
        {
            var index = Random.Range(0, _attackPositions.Count);
            var position = _attackPositions[index];

            _occupiedPositions.Add(position);
            _attackPositions.Remove(position);

            position.Released += OnReleased;

            return position;
        }
        
        public Vector3 GetRandomSpawnPosition()
        {
            var index = Random.Range(0, _spawnPositions.Count);
            return _spawnPositions[index].position;
        }

        private void OnReleased(Position position)
        {
            position.Released -= OnReleased;
            
            _occupiedPositions.Remove(position);
            _attackPositions.Add(position);
        }
    }
}