using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float m_speedX;
    public float m_speedY;
    public int m_PlayerHP;
    public GameObject m_CharaterModel;

    public void Clone(Player other)
    {
        m_speedX = other.m_speedX;
        m_speedY = other.m_speedY;
        m_PlayerHP = other.m_PlayerHP;
        m_CharaterModel = other.m_CharaterModel;
    }
}

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public Player m_Player ;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
        m_Player = new Player();
    }
    
    public void Damaged(int number)
    {
        m_Player.m_PlayerHP -= number;
    }

}


