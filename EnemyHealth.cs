using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private readonly string IsDead = "IsDead";

    private Animator _animator;
    private float _points = 30;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            LoosePoints();
    }

    private void LoosePoints()
    {
        float lostPoints = 10;
        _points -= lostPoints;

        if (_points <= 0)
            SetDeathAnimation();
    }

    private void SetDeathAnimation()
    {
        _animator.SetBool(IsDead, true);
    }

    private void Die() //called in animation event at death animation 
    {
        gameObject.SetActive(false);
    }
}
