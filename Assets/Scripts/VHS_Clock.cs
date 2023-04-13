using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS_Clock : MonoBehaviour
{

    public float x_rotation;

    public Transform myself;

    public float delay_time;

    public MasterDoorController my_controller;

    public float speed_modifier;

    public GameObject TD_object_1;
    public GameObject TD_object_2;
    public GameObject TD_object_3;

    public GameObject flash;
    public bool is_flashed;

    public VHS_Exit exit;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(is_flashed);
    }

    // Update is called once per frame
    void Update()
    {

        if (x_rotation > 360)
        {
            TD_object_1.SetActive(false);
            TD_object_2.SetActive(false);
            TD_object_3.SetActive(false);
            speed_modifier += Time.deltaTime * 30f;
            delay_time = -2f;
            if (Random.Range(1,4) == 1 && x_rotation > 620f)
            {
                is_flashed =! is_flashed;
                flash.SetActive(is_flashed);
            }
            if (x_rotation > 1020f)
            {
                exit.switch_scenes();
            }
        }

        if (!my_controller.doors_open && 360f > x_rotation)
        {
            delay_time = 2f;
        }

        if (delay_time > -1f)
        {
            delay_time -= Time.deltaTime;
            speed_modifier = 0f;
        } 

        if (0f > delay_time)
        {
            if (10f > speed_modifier)
            {
                speed_modifier += Time.deltaTime / 2f;
            }
            x_rotation += Time.deltaTime * speed_modifier;
        }

        myself.localRotation = Quaternion.Euler(x_rotation,0f,90f);
    }
}
