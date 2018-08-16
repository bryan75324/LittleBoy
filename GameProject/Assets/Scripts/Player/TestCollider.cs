using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    PlayerControl PC;
    PlayerData PD;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.name == "Character")
        //{
        //    PC = other.transform.GetComponent<PlayerControl>();
        //    Debug.Log("Trigger Enter");
        //    PC.SetSpeedVarietyY(5f);

        //    PD = other.transform.GetComponent<PlayerData>();
        //    PD.Damaged(3);
        //    Debug.Log(PD.PlayerHP.ToString());
        //}
    }

}
