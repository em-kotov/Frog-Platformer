using UnityEngine;

public class FrogHealth : MonoBehaviour
{
    private readonly string IsHit = "IsHit";
    private readonly string IsDead = "IsDead";

    private Animator _animator;
    private float _points;
    private float _maxPoints = 50;
    private bool _isHit = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _points = _maxPoints;
    }

    private void Update()
    {
        if (_isHit)
            LoosePoints();

        UpdateAnimations();

        _isHit = false;

        if (_points <= 0)
            Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyBehaviour enemy))
            _isHit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Medkit medkit))
            Heal();
    }

    private void UpdateAnimations()
    {
        _animator.SetBool(IsHit, _isHit);
    }

    private void LoosePoints()
    {
        float lostPoints = 10;
        _points -= lostPoints;

        Debug.Log($"-10. points: {_points}");
    }

    private void Heal()
    {
        float healPoints = 10;
        _points += healPoints;

        if (_points > _maxPoints)
            _points = _maxPoints;

        Debug.Log($"+10. points: {_points}");
    }

    private void Die()
    {
        _animator.SetBool(IsDead, true);
    }

    private void Disappear() //called in animation event at death animation
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
