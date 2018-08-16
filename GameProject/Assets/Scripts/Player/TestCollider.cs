using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{

    PlayerControl PC = new PlayerControl();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            Debug.Log("Trigger Enter");
            PC.SetSpeedVarietyY(5);
        }

    }
}
