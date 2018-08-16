using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private float m_speedX = 3f;
    private float m_speedY = 150f;
    private float playerMove;
    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    private void Start()
    {
        m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        playerMove = Input.GetAxis("Horizontal");
        transform.position += transform.right * playerMove * m_speedX * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody2D.AddForce(Vector2.up * m_speedY);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_Rigidbody2D.velocity = new Vector2(0f, -1.0f);
        }
    }

    /// <summary>
    /// 水平速度變化，參數傳遞-2~2
    /// </summary>
    /// <param name="speedX"></param>
    public void SpeedVarietyX(int speedX)
    {
        m_Rigidbody2D.velocity = new Vector2(speedX, 0f);
    }

    /// <summary>
    /// 往上跳躍
    /// </summary>
    /// <param name="speedY"></param>
    public void SpeedVarietyY(int speedY)
    {
        m_Rigidbody2D.AddForce(Vector2.up * speedY);
    }
}