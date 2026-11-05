using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public float spawnRadius = 4f;
    public float rayCastHeight = 10f;
    public float rayCastDistance = 20f;

    public Vector3 GetSpawnPosition()
    {
        Vector2 circle = Random.insideUnitCircle * spawnRadius;
        Vector3 position = transform.position + new Vector3(circle.x, 0f, circle.y);

        Ray ray = new Ray(position + Vector3.up * rayCastHeight, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, rayCastDistance))
        {
            position.y = hit.point.y;
        }

        return position;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}