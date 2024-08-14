using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyHealth))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly string _commandIsDead = "IsDead";

    private Animator _animator;
    private EnemyHealth _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _health.HasDied += SetDeathAnimation;
    }

    private void OnDisable()
    {
        _health.HasDied -= SetDeathAnimation;
    }

    private void SetDeathAnimation()
    {
        _animator.SetBool(_commandIsDead, true);
    }

    private void Deactivate() //used inside animation as event (death animation)
    {
        gameObject.SetActive(false);
    }
}
