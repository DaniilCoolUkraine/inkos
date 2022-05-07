using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float _movememtSpeed;

    private Rigidbody2D _rigidbody;

    //vector to store direction to move
    private Vector2 _movement;
    
    private void Awake() =>
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //part to rotate tank depends pn movement direction
        if (Input.GetKeyDown(KeyCode.D))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        if (Input.GetKeyDown(KeyCode.A))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        if (Input.GetKeyDown(KeyCode.S))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        if (Input.GetKeyDown(KeyCode.W))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _movememtSpeed * Time.fixedDeltaTime);
    }
}
