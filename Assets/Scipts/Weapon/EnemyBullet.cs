public class EnemyBullet : Bullet, IInteractable
{
    public void Interacte(Bird bird) => bird.Dead();

    public void Interacte(Enemy enemy){}
}
