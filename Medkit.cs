using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Medkit : MonoBehaviour
{
    private CircleCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out FrogHealth frogHealth))
            gameObject.SetActive(false);
    }
}
