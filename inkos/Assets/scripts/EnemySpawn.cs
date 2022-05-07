using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] 
    private GameObject[] _enemyToSpawn;

    [SerializeField]
    private List<GameObject> _enemyOnTheField;

    private int _startTankCount = 2;
    private int _maxTankCoun = 10;
    private int _currentTankCoun = 0;
    
    void Start()
    {
        for (int i = 0; i < _startTankCount; i++)
            Spawn();
    }

    void Update()
    {

        if (_currentTankCoun > _maxTankCoun)
            return;

        for (int i = 0; i < _startTankCount; i++)
        {
            if (_enemyOnTheField[i] == null)
            {
                _enemyOnTheField.RemoveAt(i);
                Spawn();
                _currentTankCoun++;
                return;
            }
        }
    }

    void Spawn()
    {
        GameObject tank = Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Length)], transform.position, Quaternion.identity);
        _enemyOnTheField.Add(tank);
    }
}
