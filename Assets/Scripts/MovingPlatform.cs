using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3[] waypointsFromOrigin = new []{new Vector3(5,0,0), new Vector3(-2,0,0)};
    [SerializeField] private Rigidbody rb;

    private int currWaypoint = 0;
    [SerializeField] private float speed = 3f;

    private Vector3 origin;

    void Awake()
    {
        origin = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, origin+waypointsFromOrigin[currWaypoint]) >= 0.1f)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, origin+waypointsFromOrigin[currWaypoint], speed * Time.deltaTime));
            
        }
        else
        {
            currWaypoint++;
            if (currWaypoint >= waypointsFromOrigin.Length)
            {
                currWaypoint = 0;
            }
        }
    }
}
