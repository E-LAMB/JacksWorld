using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{

    public GameObject tutorial_text;

    public bool got_power;
    public bool passed_barrier;

    public Transform me;
    public Transform player;

    public PlayerController the_controller;
    public bool monitoring_dash;

    public TutorialText myself;

    public Transform icon_object;
    public Transform icon_object_2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(icon_object.position);
        Debug.Log(icon_object_2.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!got_power)
        {

            if (monitoring_dash && the_controller.dashing_unlocked)
            {
                got_power = true;
            }

            if (!monitoring_dash && the_controller.spare_jump_enabled)
            {
                got_power = true; // 1810 100
                icon_object.position = new Vector3(1810f, 100f, 0f);
                icon_object_2.position = new Vector3(1810f, 100f, 0f);
            }

        }

        if (got_power && !passed_barrier)
        {
            tutorial_text.SetActive(true);

            if (me.position.x < player.position.x)
            {
                passed_barrier = true;
            }

        }

        if (passed_barrier)
        {
            tutorial_text.SetActive(false);
            myself.enabled = false;
        }
    }
}
