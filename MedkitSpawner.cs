using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private Medkit _medkitPrefab;
    [SerializeField] private float _radius;
    [SerializeField] private int _count;

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
            Create();
    }

    private void Update()
    {
        ShowRadius();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * _radius;
        return randomPosition + transform.position;
    }

    private void Create()
    {
        Instantiate(_medkitPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private void ShowRadius()
    {
        Vector3 radius = new Vector3(_radius, _radius, _radius);
        Debug.DrawLine(transform.position, transform.position + radius, Color.blue);
    }
}
