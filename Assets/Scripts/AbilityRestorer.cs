using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRestorer : MonoBehaviour
{

    public PlayerController my_controller;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            my_controller.dashing_unlocked = true;
            my_controller.spare_jump_enabled = true;
        }

    }
}
