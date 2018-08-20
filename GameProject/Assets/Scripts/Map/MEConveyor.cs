using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEConveyor : MEStandard
{
    [SerializeField] private float m_speed;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControl pc = collision.gameObject.GetComponent<PlayerControl>();
            pc.SetSpeedVarietyX(m_speed);
            Debug.Log("Set speed.");
        }
    }
}