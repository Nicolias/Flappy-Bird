using UnityEngine;

public class BirdBullet : Bullet, IInteractable
{
    [SerializeField] private ScoreCounter _scoreCounter;

    public void Interacte(Bird bird){}

    public void Interacte(Enemy enemy)
    {
        gameObject.SetActive(false);
        enemy.Dead();
        _scoreCounter.AddScore();
    }
}