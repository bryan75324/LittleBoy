using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModelChange : MonoBehaviour
{
    public Player m_Player;
    int aa;

    public void Start()
    {
        m_Player = GameObject.Find("Main").GetComponent<MainTest>().player;
    }

    public void ChangePlayerModelA()
    {
        m_Player.m_CharaterModel = Resources.Load("Character/CH01/CH01") as GameObject;
        SceneManager.LoadScene(2);
    }
    public void ChangePlayerModelB()
    {
        m_Player.m_CharaterModel = Resources.Load("Character/CH02/CH02") as GameObject;
        SceneManager.LoadScene(2);
    }
    
}
