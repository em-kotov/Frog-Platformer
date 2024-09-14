using System;
using UnityEngine;

public class FrogHealth : Health
{
    private float _maxPoints = 50;
    private float _addedPoints = 10;

    public event Action LostPoints;
    public event Action HasDied;

    private void Start()
    {
        Points = _maxPoints;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyBehaviour enemy))
        {
            LoosePoints();
            LostPoints?.Invoke();
            HasPoints();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Medkit medkit))
        {
            medkit.Deactivate();
            AddPoints(_addedPoints, _maxPoints);
        }
    }

    private void HasPoints()
    {
        if (Points <= 0)
            HasDied?.Invoke();
    }
}
