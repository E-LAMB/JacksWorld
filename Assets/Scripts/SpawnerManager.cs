using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public float active_period_min;
    public float active_period_max;
    public float dormant_period_min;
    public float dormant_period_max;

    public float period_time;

    public float clock_stage_threshold;
    public bool clock_stage_active;
    public bool spawner_is_active;

    public VHS_Clock my_clock;

    public GameObject my_managed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (my_clock.x_rotation > clock_stage_threshold)
        {
            clock_stage_active = true;
        }

        if (clock_stage_active)
        {

            period_time -= Time.deltaTime;

            if (period_time < 0f && spawner_is_active)
            {
                spawner_is_active = false;
                period_time = Random.Range(dormant_period_min, dormant_period_max);
                my_managed.SetActive(false);
            }

            if (period_time < 0f && !spawner_is_active)
            {
                spawner_is_active = true;
                period_time = Random.Range(active_period_min, active_period_max);
                my_managed.SetActive(true);
            }

        }
    }
}
