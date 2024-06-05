using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _waypointMain;
    [SerializeField] private float _speed;

    private Transform[] _waypoints;
    private int _waypointIndex = 0;

    private void Start()
    {
        _waypoints = new Transform[_waypointMain.childCount];

        AddWaypoints();
    }

    private void Update()
    {
        Patrol();
    }

    private void AddWaypoints()
    {
        for (int i = 0; i < _waypointMain.childCount; i++)
            _waypoints[i] = _waypointMain.GetChild(i).transform;
    }

    private void Patrol()
    {
        Transform currentWaypoint = _waypoints[_waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == currentWaypoint.position)
            CalculateNextWaypointIndex();
    }

    private void CalculateNextWaypointIndex()
    {
        _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;
    }
}
