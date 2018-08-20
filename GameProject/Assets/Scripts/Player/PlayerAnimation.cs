using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    private Animator m_PlayerAnimator;
    private float m_Highest;
    // Use this for initialization
    void Start()
    {
        m_PlayerAnimator = GetComponent<Animator>();
        m_Highest = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > m_Highest)
        {
            m_Highest = this.transform.position.y;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_PlayerAnimator.SetInteger("playerMove", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_PlayerAnimator.SetInteger("playerMove", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_PlayerAnimator.SetInteger("playerMove", -1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_PlayerAnimator.SetInteger("playerMove", 0);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_PlayerAnimator.SetBool("playerJump", true);
        }
        if (this.transform.position.y < m_Highest)
        {
            m_PlayerAnimator.SetBool("playerJump", false);
            m_PlayerAnimator.SetBool("playerFull", true);
            m_Highest = this.transform.position.y;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Terrain")
        {
            m_PlayerAnimator.SetBool("playerFull", false);
        }
    }
}
