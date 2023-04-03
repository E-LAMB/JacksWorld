using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    public OrangeMinigame my_minigame_manager;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "SkullBox")
        {
            my_minigame_manager.SkullPassed();
            Destroy(other);
        }

        if (other.tag == "OrangeBox")
        {
            my_minigame_manager.OrangePassed();
            Destroy(other);
        }

    }

}
