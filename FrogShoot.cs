using UnityEngine;

public class FrogShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootDistance;

    private EnemyBehaviour _closestEnemy;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectEnemy();
            Shoot();
        }
    }

    private void DetectEnemy()
    {
        float distance = 0;
        float closestDistance = Mathf.Infinity;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_shootingPoint.position, _shootDistance);
        Debug.DrawRay(_shootingPoint.position, new Vector3(1, 1) * _shootDistance, Color.red);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy))
            {
                distance = Vector2.Distance(_shootingPoint.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _closestEnemy = enemy;
                }
            }
        }
    }

    private void Shoot()
    {
        Rigidbody2D bullet = Instantiate(_bulletPrefab, _shootingPoint.position, Quaternion.identity);

        Vector3 targetPosition = _closestEnemy.transform.position;
        Vector2 targetDirection = (targetPosition - _shootingPoint.position).normalized;

        bullet.AddForce(targetDirection * _bulletSpeed, ForceMode2D.Impulse);
    }
}
