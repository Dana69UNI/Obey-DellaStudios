using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator animator;

    public void AbrirPuerta()
    {
        animator.SetTrigger("abrir");
    }
}
