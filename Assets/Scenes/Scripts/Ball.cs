using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f; // 38 degrees in radians
    public float moveSpeed = 1f;
    public float maxSpeed = 20f;
    public float minSpeed = 1f;
    public float startX = 0f;
    public float startY = 0f;
    public float speedIncreaseFactor = 1.2f;

    private void Start()
    {
        InitialPush();
    }

    private void ResetBall()
    {
        Vector2 position = new Vector2(startX, startY);
        transform.position = position;
    }

    private void InitialPush() 
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone != null)
        {
            gameManager.AddScore(scoreZone.id);
            ResetBall();
            InitialPush();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle)
        {
            rb2d.linearVelocity *= speedIncreaseFactor;
            //Slightly modify the ball's direction based on where it hit the paddle
            float y = (transform.position.y - paddle.transform.position.y) / paddle.transform.localScale.y;
            Vector2 dir = new Vector2(rb2d.linearVelocity.x > 0 ? 1 : -1, y).normalized;
            rb2d.linearVelocity = dir * Mathf.Clamp(rb2d.linearVelocity.magnitude, minSpeed, maxSpeed);
        }
    }

}
