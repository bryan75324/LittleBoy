using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject m_CharaterModel;
    private PlayerModelChange PMC;
    private int m_PlayerHP = 10;

    private void Start()
    {
        
        PMC = GetComponent<PlayerModelChange>();
        m_CharaterModel = PMC.m_Character as GameObject;
        Instantiate(GetComponent<PlayerModelChange>().m_Character as GameObject);
    }
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
