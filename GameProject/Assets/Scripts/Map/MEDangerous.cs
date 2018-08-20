using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEDangerous : MEStandard
{
    [SerializeField] private int m_Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerData pd = collision.GetComponent<PlayerData>();
            pd.Damaged(m_Damage);
        }
    }
}