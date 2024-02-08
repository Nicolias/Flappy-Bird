using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Transform _bird;
    [SerializeField] private float _xOffset;

    private Transform _selfTransform;

    private void Awake()
    {
        _selfTransform = transform;
    }

    private void Update()
    {
        Vector3 position = _selfTransform.position;

        position.x = _bird.position.x + _xOffset;
        _selfTransform.position = position;
    }
}