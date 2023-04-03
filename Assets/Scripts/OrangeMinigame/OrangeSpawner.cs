using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawner : MonoBehaviour
{

    public OrangeMinigame my_minigame_manager;

    public float timer;
    public float time_delay;

    public GameObject bad_box;
    public GameObject good_box;

    public Transform my_spawn;

    public GameObject blank_screen;

    public GameObject orange_next;
    public GameObject bad_next;

    public bool next_is_good;
    public bool rolled;

    public float warning = 2f;

    // Start is called before the first frame update
    void Start()
    {
        blank_screen.SetActive(true);
        bad_next.SetActive(false);
        orange_next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (my_minigame_manager.minigame_active)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0f;
        }

        if (timer > time_delay - warning && !rolled)
        {
            rolled = true;
            if (Random.Range(1,3) == 1)
            {
                next_is_good = true;
                orange_next.SetActive(true);
            } else
            {
                next_is_good = false;
                bad_next.SetActive(true);
            }
            blank_screen.SetActive(false);
        }

        if (timer > time_delay)
        {

            timer = 0f;

            if (next_is_good)
            {
                Instantiate(good_box, my_spawn);
            } else
            {
                Instantiate(bad_box, my_spawn);
            }

            blank_screen.SetActive(true);
            bad_next.SetActive(false);
            orange_next.SetActive(false);

            rolled = false;

            if (warning > 0.7f)
            {
                warning -= 0.1f;
            }
            if (time_delay > 3f)
            {
                time_delay -= 0.1f;
            }

        }
    }
}
