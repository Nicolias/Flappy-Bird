using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShootHandler))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private CollisionHandler _collisionHandler;

    private EnemyShootHandler _shootHandler;

    public event Action<Enemy> Die;

    private void Awake()
    {
        _shootHandler = GetComponent<EnemyShootHandler>();
    }

    private void OnEnable()
    {
        _shootHandler.Enable();
        _collisionHandler.Detected += OnDetected;
    }

    private void OnDisable()
    {
        _shootHandler.Disable();
        _collisionHandler.Detected -= OnDetected;
    }

    public void Interacte(Bird bird)
    {
        bird.Dead();
    }

    public void Interacte(Enemy enemy){}

    public void Dead()
    {
        Die?.Invoke(this);
    }

    private void OnDetected(IInteractable interactable)
    {
        interactable.Interacte(this);
    }
}