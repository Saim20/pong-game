using UnityEngine;

public class Ball : MonoBehaviour
{
    public int score;
    public float speed;
    public float radius;
    public Vector2 direction; 
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // direction is (1,1) normalized
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ball movement
        transform.Translate(direction);
        
        // Bounce Back
        if (transform.position.y < GameManager.BottomLeft.y && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.TopRight.y && direction.y > 0)
        {
            direction.y = -direction.y;
        }
        
        // Game Over
        if (transform.position.x > GameManager.TopRight.x || transform.position.x < GameManager.BottomLeft.x)
        {
            PlayerPrefs.SetInt("PS",score);
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
            score += 1;
        }
    }
}
