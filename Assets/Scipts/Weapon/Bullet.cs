using System;
using System.Collections;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _speed;

    private Transform _selfTrancform;
    private Vector3 _direction;

    public event Action<Bullet> LifeTimeOver;

    private void Awake()
    {
        _selfTrancform = transform;
    }

    private void OnEnable()
    {
        StartCoroutine(Live());
    }

    private void OnDisable()
    {
        StopCoroutine(Live());
    }

    private void Update()
    {
        if (enabled == false)
            return;

        _selfTrancform.position += Vector3.MoveTowards(Vector3.zero, _direction, _speed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        _direction = direction;
    }

    private IEnumerator Live()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float lifeTime = 0;

        while (enabled)
        {
            yield return wait;

            lifeTime += Time.deltaTime;

            if (lifeTime >= _maxLifeTime)
                LifeTimeOver?.Invoke(this);
        }
    }
}
