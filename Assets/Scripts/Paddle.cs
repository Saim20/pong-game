using UnityEngine;
using UnityEngine.EventSystems;

public class Paddle : MonoBehaviour
{
    private bool m_MoveFlag;
    private float m_Height;
    private float m_Speed;
    private float m_Move;
    private bool m_Stop = false;
    
    private bool m_IsRight;
    void Start()
    {
        // Sets height and movement speed of paddle
        m_Height = transform.localScale.y;
        m_Speed = 1f;
    }
    
    void FixedUpdate()
    {
        PaddleMovementHandler();
        PaddleMovementFlagSetter();
    }

    public void Init(bool isRightPaddle)
    {
        m_IsRight = isRightPaddle;
        Vector2 position;
        
        if (isRightPaddle)
        {
            // Place right paddle to right
            position = new Vector2(GameManager.TopRight.x,0);
            position -= Vector2.right * transform.localScale.x;
        }
        else
        {
            // Place left paddle to left
            position = new Vector2(GameManager.BottomLeft.x,0);
            position += Vector2.right * transform.localScale.x;
        }
        
        // Update paddle position
        transform.position = position;
    }

    public void PaddleMovementFlagSetter()
    {
        // Sets keys for paddle movement
        if (Input.GetKey("a") || Input.GetKey("left"))
            m_Move = 1 * m_Speed;
        else if (Input.GetKey("d") || Input.GetKey("right"))
            m_Move = -1 * m_Speed;
    }

    public void ButtonPaddleHandlerTrue()
    {
        // For onscreen button controls
        m_Stop = false;
        m_Move = 1 * m_Speed;
    }
    
    public void ButtonPaddleHandlerFalse()
    {
        // For onscreen button controls
        m_Stop = false;
        m_Move = -1 * m_Speed;
    }

    public void ButtonPaddleHandlerStop()
    {
        // For onscreen button controls
        m_Stop = true;
    }
    
    public void PaddleMovementHandler()
    {
        // Paddle movement function
        if (m_IsRight && !m_Stop)
        {
            if(m_Move < 0 && transform.position.y > GameManager.BottomLeft.y + m_Height / 2)
                transform.Translate(m_Move * Vector2.up);
            if(m_Move > 0 && transform.position.y < GameManager.TopRight.y - m_Height / 2)
                transform.Translate(m_Move * Vector2.up);
        }

        if (!m_IsRight && !m_Stop)
        {
            if(m_Move < 0 && transform.position.y < GameManager.TopRight.y - m_Height / 2)
                transform.Translate(-m_Move * Vector2.up);
            if(m_Move > 0 && transform.position.y > GameManager.BottomLeft.y + m_Height / 2)
                transform.Translate(-m_Move * Vector2.up);
        }
    }
}
