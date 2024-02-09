using TMPro;
using UnityEngine;

public class ScoreCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreCounter _model;

    private void OnEnable()
    {
        _model.Changed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _model.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}