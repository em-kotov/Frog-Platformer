using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Strawberry : MonoBehaviour
{
    private readonly string Collected = "Collected";

    [SerializeField] private float _delay;

    private Animator _animator;
    private bool _canCollect = true;

    public bool CanCollect => _canCollect;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DestroyWithEffect()
    {
        SetCollected();
        StartCoroutine(Destroy());
    }

    private void SetCollected()
    {
        _canCollect = false;
    }

    private IEnumerator Destroy()
    {
        _animator.SetTrigger(Collected);

        yield return new WaitForSeconds(_delay);

        Destroy(gameObject);
    }
}
