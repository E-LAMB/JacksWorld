using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    public float boost_height;
    public PlayerController player_script;

    void Start()
    {
        player_script = GameObject.Find("PlayerCollective").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player_script.Jump(boost_height);
        }
    }

}
