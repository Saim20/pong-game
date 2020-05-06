using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public int score;
    public float speed;
    public float radius;
    public Text scoreText;
    
    private Vector2 _direction;
    private float _speed = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        _direction = Vector2.one.normalized; // direction is (1,1) normalized
        transform.position = new Vector3(0,0,0);
    }

    private void FixedUpdate()
    {
        // Sets hardness with score
        switch (score)
        {
            case 5:
                _speed = 1.5f;
                break;
            case 10:
                _speed = 2f;
                break;
            case 20:
                _speed = 2.5f;
                break;
            case 40:
                _speed = 3f;
                break;
            case 80:
                _speed = 3.5f;
                break;
            case 160:
                _speed = 4f;
                break;
        }
        
        // Ball movement
        transform.Translate(_direction * _speed);
        
        // Bounce Back
        if (transform.position.y < GameManager.BottomLeft.y && _direction.y < 0)
        {
            _direction.y = -_direction.y;
        }
        if (transform.position.y > GameManager.TopRight.y && _direction.y > 0)
        {
            _direction.y = -_direction.y;
        }
        
        // Game Over
        if (!(transform.position.x > (GameManager.TopRight.x + transform.localScale.x/2)) &&
            !(transform.position.x < (GameManager.BottomLeft.x - transform.localScale.x/2))) return;
        PlayerPrefs.SetInt("PS",score);
        FindObjectOfType<GameManager>().GameOver();
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collision with paddle
        if (!other.CompareTag("Paddle")) return;
        _direction.x = -_direction.x;
        
        // Keep score
        score += 1;
        FindObjectOfType<Text>().text = score.ToString();

    }
}
