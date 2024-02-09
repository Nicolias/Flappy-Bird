using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _prefab;

    private Queue<Bullet> _pool = new Queue<Bullet>();
    private List<Bullet> _createdBullet = new List<Bullet>();

    private void OnDisable()
    {
        _createdBullet.ForEach(bullet => bullet.LifeTimeOver -= Put);
    }

    public void Reset()
    {
        _createdBullet.ForEach(bullet =>
        {
            if (_pool.Contains(bullet) == false)
                Put(bullet);
        });
    }

    public Bullet GetBullet()
    {
        if (_pool.Count == 0)
        {
            Bullet bullet = Instantiate(_prefab, _container);
            bullet.LifeTimeOver += Put;
            _createdBullet.Add(bullet);
            
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