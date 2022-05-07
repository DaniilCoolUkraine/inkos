using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Shoot _enemyShot;

    [SerializeField] 
    private GameObject _projectile;

    [SerializeField] 
    private Vector3 _offset;
    
    private void Start()
    {
        _enemyShot = gameObject.GetComponent<Shoot>();
    }

    public void EnemyShot()
    {
        _enemyShot.SpawnProjectile(_projectile, transform.position + _offset, transform.rotation);
    }
    
}
