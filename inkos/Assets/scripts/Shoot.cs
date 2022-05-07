using UnityEngine;

public class Shoot : MonoBehaviour
{
    public void SpawnProjectile(GameObject projectile, Vector3 position, Quaternion direction) =>
        Instantiate(projectile, position, direction);
}
