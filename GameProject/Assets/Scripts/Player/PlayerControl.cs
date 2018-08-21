using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private float m_speedX = 3f;
    private float m_speedY = 5f;
    private float m_PlayerMove;
    private float m_PlayerJump;
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
        m_PlayerAnimator.speed = (m_speedX == 10f) ? 10 : 1;


        m_PlayerMove = Input.GetAxis("Horizontal");
        m_PlayerJump = Input.GetAxis("Jump");


        transform.position += transform.right * System.Math.Abs(m_PlayerMove) * m_speedX * Time.deltaTime;

        if (m_PlayerMove > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (m_PlayerMove < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        m_PlayerAnimator.SetFloat("Speed", System.Math.Abs(m_PlayerMove));




        if (this.transform.position.y < m_Highest)
        {
            m_PlayerAnimator.SetBool("Fall", true);
            m_Highest = this.transform.position.y;
        }
        m_JumpRay = Physics2D.Raycast(transform.position, -transform.up, 1, 1 << LayerMask.NameToLayer("Terrain"));
        if (m_JumpRay.collider)
        {
            isGround = true;
        }
    }

    private void FixedUpdate()
    {
        if (m_PlayerJump > 0 && isGround)
        {
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