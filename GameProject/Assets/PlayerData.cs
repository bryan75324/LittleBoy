using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    PlayerControl player=new PlayerControl;
    public int playerHP = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BeingAttacked(int damage)
    {
        playerHP -= damage;
    }
}
