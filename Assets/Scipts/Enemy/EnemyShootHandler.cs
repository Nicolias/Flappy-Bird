using System.Collections;
using UnityEngine;

public class EnemyShootHandler : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Gun _gun;

    public void Enable()
    {
        StartCoroutine(Shoot());
    }

    public void Disable()
    {
        StopCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            _gun.Shoot();
        }
    }
}