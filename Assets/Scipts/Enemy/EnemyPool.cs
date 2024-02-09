using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;

    private Queue<Enemy> _pool = new Queue<Enemy>();
    private List<Enemy> _createdEnemy = new List<Enemy>();
    
    private void OnDisable()
    {
        _createdEnemy.ForEach(enemy => enemy.Die -= Put);
    }

    public void Reset()
    {
        _createdEnemy.ForEach(enemy => 
        {
            enemy.Reset();

            if (_pool.Contains(enemy) == false)
                Put(enemy);
        });
    }

    public Enemy GetEnemy()
    {
        if (_pool.Count == 0)
        {
            Enemy enemy = Instantiate(_prefab, _container);
            enemy.Die += Put;
            enemy.gameObject.SetActive(true);
            _createdEnemy.Add(enemy);

            return enemy;
        }

        return _pool.Dequeue();
    }

    private void Put(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}