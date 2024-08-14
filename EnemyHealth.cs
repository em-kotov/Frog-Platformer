using System;
using UnityEngine;

public class EnemyHealth : Health
{
    private float _points = 30;

    public event Action HasDied;

    private void Start()
    {
        Points = _points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            LoosePoints();
            CheckForDeath();
        }
    }

    private void CheckForDeath()
    {
        if (Points <= 0)
            HasDied?.Invoke();
    }
}
