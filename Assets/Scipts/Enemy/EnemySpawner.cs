using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private EnemyPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    private IEnumerator GenerateEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            Spawn();
        }
    }

    private void Spawn()
    {
        Enemy enemy = _pool.GetEnemy();
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
    }
}
