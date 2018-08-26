using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float m_speedX = 3f;
    public float m_speedY = 5f;
    public int m_PlayerHP = 10;
    public GameObject m_CharaterModel;
}
public class PlayerData : MonoBehaviour
{
    public Player m_Player;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        m_Player = new Player();
    }
    private void Start()
    {
        
    }
    
    public void Damaged(int number)
    {
        m_Player.m_PlayerHP -= number;
    }

}


