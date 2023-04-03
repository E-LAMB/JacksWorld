using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraJump : MonoBehaviour
{

    public CameraController my_controller;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            my_controller.my_height = -5000f;
        }

    }
}
