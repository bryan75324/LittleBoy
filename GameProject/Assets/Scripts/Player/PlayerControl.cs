using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private float m_speedX = 3f;
    private float m_speedY;
    private float playerMove;

    private bool isGround = false;
    private int jumpCount = 0;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_PlayerAnimator;

    // Use this for initialization
    private void Start()
    {
        m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
        m_PlayerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_speedX = 10f;
        }
        else
        {
            m_speedX = 3f;
        }
        playerMove = Input.GetAxis("Horizontal");
        transform.position += transform.right * playerMove * m_speedX * Time.deltaTime;

        m_PlayerAnimator.SetInteger("playerMoveMode", (int)playerMove*10);

    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            if (jumpCount == 0)
            {
                m_speedY = 5f;
                m_Rigidbody2D.velocity = new Vector2(0f, m_speedY);
            }
            if (jumpCount == 1)
            {
                m_speedY = 7f;
                m_Rigidbody2D.velocity = new Vector2(0f, m_speedY);
            }
            jumpCount += 1;
            if (jumpCount > 1)
            {
                isGround = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_Rigidbody2D.velocity = new Vector2(0f, -1.0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Terrain")
        {
            isGround = true;
            jumpCount = 0;
        }
    }
    /// <summary>
    /// 水平速度變化，參數傳遞-3~3，右邊為正
    /// </summary>
    /// <param name="speedX"></param>
    public void SetSpeedVarietyX(float speedX)
    {
        m_Rigidbody2D.velocity = new Vector2(speedX, 0f);
    }

    /// <summary>
    /// 垂直速度變化，往上跳躍建議設5
    /// </summary>
    /// <param name="speedY"></param>
    public void SetSpeedVarietyY(float speedY)
    {
        m_Rigidbody2D.velocity = new Vector2(0f, speedY);
    }
}