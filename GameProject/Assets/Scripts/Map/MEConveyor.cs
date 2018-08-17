using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEConveyor : MEStandard
{
    [SerializeField] private float m_speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerControl pc = collision.GetComponent<PlayerControl>();
            pc.SetSpeedVarietyX(m_speed);
        }
    }
}