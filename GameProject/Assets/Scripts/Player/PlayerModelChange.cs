using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelChange : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangePlayerModel()
    {
        PlayerAnimation.Character = Resources.Load("PlayerMain") as GameObject;
    }
}
