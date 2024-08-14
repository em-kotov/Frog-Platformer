using UnityEngine;

[RequireComponent(typeof(Animator), typeof(FrogHealth))]
[RequireComponent(typeof(CapsuleCollider2D), typeof(SpriteRenderer))]
public class FrogAnimator : MonoBehaviour
{
    private readonly string _commandSpeed = "Speed";
    private readonly string _commandIsGrounded = "IsGrounded";
    private readonly string _commandWasHit = "WasHit";
    private readonly string _commandIsDead = "IsDead";

    private Animator _animator;
    private FrogHealth _health;
    private FrogMovement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<FrogHealth>();
        _movement = GetComponent<FrogMovement>();
    }

    private void OnEnable()
    {
        _health.LostPoints += PlayHitAnimation;
        _health.HasDied += SetDeathAnimation;
        _movement.SpeedChanged += UpdateSpeed;
        _movement.IsGroundedChanged += UpdateJump;
    }

    private void OnDisable()
    {
        _health.LostPoints -= PlayHitAnimation;
        _health.HasDied -= SetDeathAnimation;
        _movement.SpeedChanged -= UpdateSpeed;
        _movement.IsGroundedChanged -= UpdateJump;
    }

    private void UpdateSpeed(float speed)
    {
        _animator.SetFloat(_commandSpeed, speed);
    }
    
    private void UpdateJump(bool isGrounded)
    {
        _animator.SetBool(_commandIsGrounded, isGrounded);
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger(_commandWasHit);
    }

    private void SetDeathAnimation()
    {
        _animator.SetBool(_commandIsDead, true);
    }

    private void Disappear() //used inside animation as event (death animation)
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
