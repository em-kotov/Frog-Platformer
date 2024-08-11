using UnityEngine;

public class EnemyHealth : Health
{
    private float points = 30;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Points = points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
            LoosePoints();
    }

    public override void LoosePoints()
    {
        base.LoosePoints();
        CheckForDeath();
    }

    private void Deactivate() //called in animation event at death animation 
    {
        gameObject.SetActive(false);
    }
}
