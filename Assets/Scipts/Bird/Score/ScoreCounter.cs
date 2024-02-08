using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score = 0;

    public event Action<int> Changed;

    public void AddScore()
    {
        _score++;

        Changed?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;

        Changed?.Invoke(_score);
    }
}
