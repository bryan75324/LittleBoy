using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    private float m_speedX = 3f;
    private float m_speedY;
    private Rigidbody2D m_Rigidbody2D;
    // Use this for initialization
    void Start()
    {
        m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerMove = Input.GetAxis("Horizontal");
        transform.position += transform.right * playerMove * m_speedX * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody2D.AddForce(Vector2.up * 150f);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_speedY = -1.0f;
            m_Rigidbody2D.velocity = new Vector2(0f,m_speedY);
        }
    }
}
