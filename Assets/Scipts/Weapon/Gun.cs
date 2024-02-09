using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletPool _pool;
    [SerializeField] private Vector3 _direction;

    public void Reset()
    {
        _pool.Reset();
    }

    public void Shoot()
    {
        Bullet bullet = _pool.GetBullet();
        bullet.transform.position = _shootPoint.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.MoveTo(_direction);
    }
}
