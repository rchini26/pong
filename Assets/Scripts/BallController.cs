using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _startingVelocity = new (-5f, -5f);
    
    public GameManager gameManager;

    public float speedUp = 1.1f;

   public void ResetBall()
    {
        transform.position = Vector3.zero;
        if (_rb == null) _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = _startingVelocity;
    }
 void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = _rb.linearVelocity;
            newVelocity.y = -newVelocity.y;
            _rb.linearVelocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _rb.linearVelocity = new Vector2(-_rb.linearVelocity.x, _rb.linearVelocity.y);
            _rb.linearVelocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("Enemy Wall"))
        {
            gameManager.EnemyScore();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("Player Wall"))
        {
            gameManager.PlayerScore();
            ResetBall();
        }
    }
}
