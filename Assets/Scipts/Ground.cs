using UnityEngine;

public class Ground : MonoBehaviour, IInteractable
{
    public void Interacte(Bird bird)
    {
        bird.Dead();
    }

    public void Interacte(Enemy enemy){}
}
