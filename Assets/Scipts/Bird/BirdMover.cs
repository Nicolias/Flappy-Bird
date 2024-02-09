using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Transform _selfTransform;

    private Vector3 _startPostition;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _selfTransform = transform;

        _startPostition = _selfTransform.position;
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            _selfTransform.rotation = _maxRotation;
        }

        _selfTransform.rotation = 
            Quaternion.Lerp
            (
                _selfTransform.rotation,
                _minRotation,
                _rotationSpeed * Time.deltaTime
            );
    }

    public void Reset()
    {
        _selfTransform.position = _startPostition;
        _rigidbody.velocity = new Vector2(0, 0);
        _selfTransform.rotation = Quaternion.identity;
    }
}
