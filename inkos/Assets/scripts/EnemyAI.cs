using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private Vector2 _randomSpot;

    [SerializeField]
    private Vector2 _minPos, _maxPos;

    [SerializeField] 
    private int _points;
    
    private List<GameObject> _pointsOfInterest = new List<GameObject>();
    private GameObject _pointToMove;

    [SerializeField] 
    private float _velocity;
    
    [SerializeField] 
    private float _timeToMove, _currTime;

    [SerializeField]
    private EnemyShoot _enemyShoot;
        
    private void Start()
    {
        _pointsOfInterest.Add(GameObject.FindGameObjectWithTag("Player"));
        _pointsOfInterest.Add(GameObject.FindGameObjectWithTag("Finish"));
        
         _pointToMove = _pointToMove = _pointsOfInterest[0];
    }
    
    void Update()
    {
        if (Dist(_pointsOfInterest[0]) > Dist(_pointsOfInterest[1]))
            _pointToMove = _pointsOfInterest[1];
        else
            _pointToMove = _pointsOfInterest[0];

        if (_currTime > 0)
            _currTime -= Time.deltaTime;
        else
        {
            _randomSpot = GenerateRandomSpot(_minPos, _maxPos) +
                          (Vector2) _pointToMove.transform.position * Random.Range(10, 15);
            _currTime = _timeToMove;
        }
        if (_currTime > 2 && _currTime < 7)
            _enemyShoot.EnemyShot();
    }

    private void FixedUpdate()
    {
        //_rigidbody.MovePosition(_rigidbody.position + _randomSpot * _velocity * Time.fixedDeltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _randomSpot, _velocity * Time.fixedDeltaTime);
        
        if (_pointToMove.transform.position.x > transform.position.x)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        if (_pointToMove.transform.position.x < transform.position.x)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        if (_pointToMove.transform.position.y > transform.position.y)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (_pointToMove.transform.position.y < transform.position.y)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    private Vector2 GenerateRandomSpot(Vector2 minPos, Vector2 maxPos)
    {
        Vector2 res = new Vector2
        (
            Random.Range(minPos.x, maxPos.x),
            Random.Range(minPos.y, maxPos.y)
        );
        return res;
    }

    private float Dist(GameObject objectToFind)
    {
        float res = (gameObject.transform.position - objectToFind.transform.position).magnitude;
        return res;
    }

    public int GetPoints() => _points;
}
