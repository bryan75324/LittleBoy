using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private float speed=10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float playerMove=Input.GetAxis("Horizontal");

        transform.position += transform.right * playerMove * speed*Time.deltaTime;

	}
}
