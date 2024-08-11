using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Strawberry : Collectable
{
    private readonly string _commandCollected = "Collected";

    private Animator _animator;

    public bool CanCollect { get; private set; } = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DeactivateWithEffect()
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
        _animator.SetTrigger(_commandCollected);
    }
}
