using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;
    public static Vector2 BottomLeft;
    public static Vector2 TopRight;

    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main != null)
        {
            BottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            TopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        Instantiate(ball);
        Paddle paddle1 = Instantiate(paddle);
        Paddle paddle2 = Instantiate(paddle);
        paddle1.Init(true);
        paddle2.Init(false);
    }
}
