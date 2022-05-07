using UnityEngine;
using UnityEngine.Tilemaps;

public interface Damagable
{
    void Destroy(Vector3Int position, Tilemap map);
}