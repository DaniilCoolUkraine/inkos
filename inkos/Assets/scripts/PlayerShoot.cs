using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    //list to store destructable tiles
    public List<DestructiveTiles> _tileDatas;
    
    private Shoot _playerShoot;

    [SerializeField] 
    private GameObject _projectile;

    [SerializeField] 
    private Vector3 _offset;
    
    private void Start()
    {
        _playerShoot = gameObject.GetComponent<Shoot>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerShoot.SpawnProjectile(_projectile, transform.position + _offset, transform.rotation);
        }       
    }
}
