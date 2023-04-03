using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject to_spawn_a;
    public GameObject to_spawn_b;
    public GameObject to_spawn_c;
    public GameObject to_spawn_d;
    public GameObject to_spawn_e;
    public GameObject to_spawn_f;

    public int current_spawn;

    public float time_delay;
    public float timer;

    public Transform position;

    // Start is called before the first frame update
    void Start()
    {
        current_spawn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time_delay)
        {
            timer = 0f;

            if (current_spawn == 1)
            {
                Instantiate(to_spawn_a,position);
            } else if (current_spawn == 2)
            {
                Instantiate(to_spawn_b,position);
            } else if (current_spawn == 3)
            {
                Instantiate(to_spawn_c,position);
            } else if (current_spawn == 4)
            {
                Instantiate(to_spawn_d,position);
            } else if (current_spawn == 5)
            {
                Instantiate(to_spawn_e,position);
            } else if (current_spawn == 6)
            {
                Instantiate(to_spawn_f,position);
                current_spawn = 0;
            }
            current_spawn += 1;
        }

    }
}
