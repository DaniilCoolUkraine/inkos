using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField] 
    private GameObject _player;

    // [SerializeField] 
    // private Vector3 maxCorner, minCorner;
    
    public Vector3 offset;
    
    void Update()
    {
        //gameObject.transform.position = VectorClamp(_player.transform.position, minCorner, maxCorner) + offset;
        gameObject.transform.position = _player.transform.position + offset;
    }

    // private Vector3 VectorClamp(Vector3 vecToClamp, Vector3 min, Vector3 max)
    // {
    //     Vector3 res = new Vector3
    //     (
    //         Mathf.Clamp(vecToClamp.x, min.x, max.x),
    //         Mathf.Clamp(vecToClamp.y, min.y, max.y),
    //         Mathf.Clamp(vecToClamp.z, min.z, max.z)
    //     );
    //     return res;
    // }
    
}
