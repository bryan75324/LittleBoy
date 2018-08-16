using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int m_PlayerHP=10;

    public int PlayerHP
    {
        get
        {
            return m_PlayerHP;
        }
        private set
        {
            if (value < 0)
                m_PlayerHP = 0;
            else
                m_PlayerHP = value;
        }
    }
    public void Damaged(int number)
    {
        PlayerHP -= number;
    }
}
