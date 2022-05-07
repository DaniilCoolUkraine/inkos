using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] 
    private int _health;

    public void Destroy()
    {
        if (_health <= 1)
            Destroy(gameObject);
        else
            _health -= 1;
    }
}