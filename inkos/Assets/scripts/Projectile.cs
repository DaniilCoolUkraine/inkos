using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private PlayerShoot _player;

    [SerializeField] 
    private float _speed;
    private Rigidbody2D _rigidbody;

    [SerializeField] 
    private Tilemap _map;

    [SerializeField]
    private List<DestructiveTiles> _tileDatas;
    private Dictionary<TileBase, DestructiveTiles> _dataFromTile;

    private Text _points;
    private void Awake()
    {
        _map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
        _player = GameObject.FindGameObjectWithTag("PlayerShootZone").GetComponent<PlayerShoot>();


        _tileDatas = _player._tileDatas;
        _dataFromTile = new Dictionary<TileBase, DestructiveTiles>();

        foreach (var tileData in _tileDatas)
            foreach (var tile in tileData.tiles)
                _dataFromTile.Add(tile, tileData);
        
        _points = GameObject.Find("Points").GetComponent<Text>();
    }

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.velocity = transform.TransformDirection(Vector3.up) * _speed;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Vector3 hitPosition = Vector3.zero;
        
        foreach (ContactPoint2D hit in col.contacts)
        {
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
        }

        Vector3Int cellPos = _map.WorldToCell(hitPosition);
        
        
        if(_map.GetTile(cellPos)!=null)
            if( _map.GetTile(cellPos).name.Contains("Destr")) 
                _dataFromTile[_map.GetTile(cellPos)].Destroy(cellPos, _map);

        if (col.collider.name.Contains("Enemy"))
        {
            col.collider.gameObject.GetComponent<EnemyHp>().Destroy();

            int curPoints = int.Parse(_points.text);
            curPoints += col.collider.gameObject.GetComponent<EnemyAI>().GetPoints();
            _points.text = curPoints.ToString();
        }

        if (col.collider.name.Contains("player"))
            col.collider.gameObject.GetComponent<PlayerHp>().Destroy();

        Destroy(gameObject);
    }
}
