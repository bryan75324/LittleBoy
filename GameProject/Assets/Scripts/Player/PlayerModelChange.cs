using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModelChange : MonoBehaviour
{
    public Player m_Player;
    public List<GameObject> go_Character;
    public void Start()
    {
        m_Player = GameObject.Find("Main").GetComponent<PlayerData>().m_Player;
        go_Character = new List<GameObject>();
        go_Character.Add(Resources.Load("Character/CH01/CH01") as GameObject);
        go_Character.Add(Resources.Load("Character/CH02/CH02") as GameObject);
        go_Character.Add(Resources.Load("Character/CH03/CH03") as GameObject);
    }

    public void ChangePlayerModelA()
    {
        m_Player.m_CharaterModel = go_Character[0];
        SceneManager.LoadScene(2);
    }
    public void ChangePlayerModelB()
    {
        m_Player.m_CharaterModel = go_Character[1];
        SceneManager.LoadScene(2);
    }
    public void ChangePlayerModelC()
    {
        m_Player.m_CharaterModel = go_Character[2];
        SceneManager.LoadScene(2);
    }
    public void ChangePlayerModelRN()
    {
        int i;
        System.Random RD = new System.Random();
        i = (int)(RD.NextDouble()*3);
        m_Player.m_CharaterModel = go_Character[i];
        SceneManager.LoadScene(2);
    }
}
