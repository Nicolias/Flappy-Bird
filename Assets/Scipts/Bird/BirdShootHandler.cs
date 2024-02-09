using UnityEngine;

public class CharacterShootHandler : MonoBehaviour
{
    [SerializeField] public Gun _gun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _gun.Shoot();
    }

    public void Reset()
    {
        _gun.Reset();
    }
}