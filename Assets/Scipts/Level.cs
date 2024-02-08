using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private void OnEnable()
    {
        _bird.GameOver += EndGame;
    }

    private void OnDisable()
    {
        _bird.GameOver -= EndGame;        
    }

    private void Reset()
    {
        _bird.Reset();
        Time.timeScale = 1;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
    }
}