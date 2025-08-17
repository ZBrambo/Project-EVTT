using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int playerID;
    public float moveSpeed = 5f;

    private Vector2 _moveDirection;

    public InputActionReference moveAction;

    public void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 position = rb2d.position;
        position.y += _moveDirection.y * moveSpeed * Time.fixedDeltaTime;
        // Clamp the paddle's position to the screen bounds
        position.y = Mathf.Clamp(position.y, -4.5f, 4.5f); // Adjust these values based on your game area
        rb2d.MovePosition(position);
    }
}
