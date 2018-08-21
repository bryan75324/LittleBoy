using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModelChange : MonoBehaviour
{

    public Object m_Character;
    // Use this for initialization
    void Start()
    {
        m_Character = new Object();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangePlayerModelA()
    {
        m_Character = Resources.Load("Character/CH01/CH01");
        Debug.Log(m_Character.name);
        SceneManager.LoadScene(2);

    }
    public void ChangePlayerModelB()
    {
        m_Character = Resources.Load("Character/CH02/CH02");
        Debug.Log(m_Character.name);
        SceneManager.LoadScene(2);
    }

    private void CreateCharacter()
    {
        GameObject player = GameObject.Instantiate( Resources.Load("PlayerMain") as GameObject);
        player.GetComponent<PlayerData>().m_CharaterModel = m_Character as GameObject;
    }
}
