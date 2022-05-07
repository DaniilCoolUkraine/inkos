using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class DestructiveTiles : ScriptableObject, Damagable
{
    public TileBase[] tiles;

    public void Destroy(Vector3Int position, Tilemap map) =>
        map.SetTile(position, null);

}