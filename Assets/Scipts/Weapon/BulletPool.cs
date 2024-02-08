using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _prefab;

    private Queue<Bullet> _pool = new Queue<Bullet>();

    private void OnDisable()
    {
        _pool.ToList().ForEach(bullet => bullet.LifeTimeOver -= Put);
    }

    public Bullet GetBullet()
    {
        if (_pool.Count == 0)
        {
            Bullet bullet = Instantiate(_prefab, _container);
            bullet.LifeTimeOver += Put;
            
            return bullet;
        }

        return _pool.Dequeue();
    }    

    private void Put(Bullet bullet)
    {
        if (bullet == null)
            throw new ArgumentNullException();

        _pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}