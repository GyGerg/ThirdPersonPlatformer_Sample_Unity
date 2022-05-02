using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemyController) && enemyController.CurrentWaypoint == this)
        {
            enemyController.NextWaypoint();
        }
    }
}
