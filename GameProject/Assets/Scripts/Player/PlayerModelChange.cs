using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModelChange : MonoBehaviour
{
    public Player m_Player
    {
        get { return GameObject.Find("Main").GetComponent<PlayerData>().m_Player; }
        set { m_Player.Clone(value); }
    }
    public List<GameObject> go_Character = new List<GameObject>();
    public List<Player> Players = new List<Player>();

    public void Start()
    {
        go_Character.Add(Resources.Load("Character/CH01/CH01") as GameObject);
        go_Character.Add(Resources.Load("Character/CH02/CH02") as GameObject);
        go_Character.Add(Resources.Load("Character/CH03/CH03") as GameObject);

        CreatePlayer(3, 5, 10, go_Character[0]);
        CreatePlayer(2, 8, 10, go_Character[1]);
        CreatePlayer(4, 10, 10, go_Character[2]);
    }

    private void CreatePlayer(float speedX, float speedY, int Hp, GameObject model)
    {
        Player player = new Player()
        {
            m_speedX = speedX,
            m_speedY = speedY,
            m_PlayerHP = Hp,
            m_CharaterModel = model
        };
        Players.Add(player);
    }

    public void ChangePlayerModelA(int i)
    {
        m_Player = Players[i];
        SceneManager.LoadScene(2);
    }
    
    public void ChangePlayerModelRN()
    {
        int i;
        System.Random RD = new System.Random();
        i = (int)(RD.NextDouble() * 3);
        m_Player = Players[i];
        SceneManager.LoadScene(2);
    }
}
