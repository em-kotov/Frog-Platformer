using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(SpriteRenderer))]
public class FrogHealth : Health
{
    private readonly string _commandIsHit = "IsHit";
    
    private float _maxPoints = 50;
    private float _addedPoints = 10;
    private bool _isHit = false;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Points = _maxPoints;
    }

    private void Update()
    {
        if (_isHit)
            LoosePoints();

        UpdateHitAnimation();

        _isHit = false;

        CheckForDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyBehaviour enemy))
            _isHit = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Medkit medkit))
        {
            medkit.Deactivate();
            AddPoints(_addedPoints, _maxPoints);
        }
    }

    private void UpdateHitAnimation()
    {
        Animator.SetBool(_commandIsHit, _isHit);
    }

    public override void LoosePoints()
    {
        base.LoosePoints();
        Debug.Log($"-10. points: {Points}");
    }

    public override void AddPoints(float addedPoints, float maxPoints)
    {
        base.AddPoints(_addedPoints, _maxPoints);
        Debug.Log($"+10. points: {Points}");
    }

    private void Disappear() //called in animation event at death animation
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
