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
            // Place to right
            position = new Vector2(GameManager.TopRight.x,0);
            position -= Vector2.right * transform.localScale.x;
        }
        else
        {
            // Place to left
            position = new Vector2(GameManager.BottomLeft.x,0);
            position += Vector2.right * transform.localScale.x;
        }
        
        // Update paddle position
        transform.position = position;
    }

    public void PaddleMovementFlagSetter()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
            m_Move = 1 * m_Speed;
        else if (Input.GetKey("d") || Input.GetKey("right"))
            m_Move = -1 * m_Speed;
    }

    public void ButtonPaddleHandlerTrue()
    {
        m_Stop = false;
        m_Move = 1 * m_Speed;
    }
    
    public void ButtonPaddleHandlerFalse()
    {
        m_Stop = false;
        m_Move = -1 * m_Speed;
    }

    public void ButtonPaddleHandlerStop()
    {
        m_Stop = true;
    }
    
    public void PaddleMovementHandler()
    {
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
