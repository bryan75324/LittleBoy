using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private float m_speedX = 3f;
    private float m_speedY;
    private float playerMove;
    private float m_Highest;
    private Animator m_PlayerAnimator;


    private RaycastHit2D m_JumpRay;
    private bool isGround = false;
    private int jumpCount = 0;

    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    private void Start()
    {
        m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
        m_PlayerAnimator = GetComponentInChildren<Animator>();
        m_Highest = this.transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.transform.position.y > m_Highest)
        {
            m_Highest = this.transform.position.y;
        }

        m_speedX = (Input.GetKey(KeyCode.LeftShift)) ? 10f : 3f;

        playerMove = Input.GetAxis("Horizontal");
        transform.position += transform.right * playerMove * m_speedX * Time.deltaTime;

        m_PlayerAnimator.SetFloat("Speed", playerMove);

        if (this.transform.position.y < m_Highest)
        {
            m_PlayerAnimator.SetBool("Fall", true);
            m_Highest = this.transform.position.y;
        }
        m_JumpRay = Physics2D.Raycast(transform.position, -transform.up, 1, 1 << LayerMask.NameToLayer("Terrain"));
        if (m_JumpRay.collider)
        {
            Debug.Log(m_JumpRay.transform.name);
            isGround = true;
        }
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -1), Color.red);
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            m_speedY = 5f;
            m_Rigidbody2D.velocity = new Vector2(0f, m_speedY);

            m_PlayerAnimator.SetTrigger("Jump");
            isGround = false;
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
            m_PlayerAnimator.SetBool("Fall", false);
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