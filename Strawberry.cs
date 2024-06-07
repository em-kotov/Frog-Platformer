using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Strawberry : MonoBehaviour
{
    private readonly string Collected = "Collected";

    private Animator _animator;

    public bool CanCollect { get; private set; } = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DestroyWithEffect()
    {
        SetCollected();
        SetAnimation();
    }

    private void SetCollected()
    {
        CanCollect = false;
    }

    private void SetAnimation()
    {
        _animator.SetTrigger(Collected);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
