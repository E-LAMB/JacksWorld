using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS_Clock : MonoBehaviour
{

    public float x_rotation;

    public Transform myself;

    public float delay_time;

    public MasterDoorController my_controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!my_controller.doors_open)
        {
            delay_time = 3f;
        }

        if (delay_time > -1f)
        {
            delay_time -= Time.deltaTime;
        }

        if (0f > delay_time)
        {
            x_rotation += Time.deltaTime * 2f;
        }

        myself.localRotation = Quaternion.Euler(x_rotation,0f,90f);
    }
}
