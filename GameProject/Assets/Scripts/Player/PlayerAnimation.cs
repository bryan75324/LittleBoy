using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    
    private Animator m_PlayerAnimator;
    // Use this for initialization
    void Start () {
        m_PlayerAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
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
    }
}
