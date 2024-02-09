using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private CharacterShootHandler _shootHandler;

    private CollisionHandler _collisionHandler;
    private ScoreCounter _scoreCounter;
    private BirdMover _mover;

    public event Action GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _mover = GetComponent<BirdMover>();
    }

    private void OnEnable()
    {
        _collisionHandler.Detected += OnInteracte;
    }

    private void OnDisable()
    {
        _collisionHandler.Detected -= OnInteracte;
    }

    public void Reset()
    {
        _mover.Reset();
        _scoreCounter.Reset();
        _shootHandler.Reset();        
    }

    public void Dead()
    {
        GameOver?.Invoke();
    }

    private void OnInteracte(IInteractable interactable)
    {
        interactable.Interacte(this);
    }
}