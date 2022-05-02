using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Waypoint[] waypoints;
    public Waypoint CurrentWaypoint => waypoints[_currWaypoint];
    private int _currWaypoint = 0;
    [SerializeField] private float speed = 3f;

    [SerializeField] private int pointValue = 10;
    public int PointValue => pointValue;

    private NavMeshPath _path;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void NextWaypoint()
    {
        _currWaypoint++;
        if (_currWaypoint >= waypoints.Length)
        {
            _currWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if(waypoints == null || waypoints.Length == 0)
        {
            return;
        }
        var pos = waypoints[_currWaypoint].transform.position;
            var dir = (pos - transform.position);
            dir.y = 0;
            if(dir.magnitude > 1f)
                dir.Normalize();
            rb.AddForce(dir * speed, ForceMode.Impulse);
    }
}
