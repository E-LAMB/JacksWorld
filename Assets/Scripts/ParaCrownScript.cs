using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaCrownScript : MonoBehaviour
{

    public SaveSystem the_sys;

    public int new_level;

    public GameObject prompt;
    
    public bool player_close;
    public bool interacted_with;
    public bool is_active;

    public bool has_checked_for_ending;

    public SpriteRenderer my_render;

    public float range;
    public LayerMask player_layer;

    public float my_activator_time;
    public GameObject activator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        my_activator_time += Time.deltaTime;
        if (my_activator_time > 1f)
        {
            activator.SetActive(true);
        }

        if (the_sys.data_PROGRESS_para == 0 && !has_checked_for_ending)
        {
            has_checked_for_ending = true;
            bool seen_an_ending = false;
            if (the_sys.data_ENDING_good != 0) {seen_an_ending = true;}
            if (the_sys.data_ENDING_bad != 0) {seen_an_ending = true;}
            if (the_sys.data_ENDING_safe != 0) {seen_an_ending = true;}
            if (the_sys.data_ENDING_stolen != 0) {seen_an_ending = true;}
            if (seen_an_ending)
            {
                the_sys.data_PROGRESS_para = 1;
                Mind.para_progress = 1;
                the_sys.SaveSystem_SAVE();
            }
        }

        if (the_sys.data_PROGRESS_para != 1)
        {
            is_active = false;
        } else
        {
            is_active = true;
        }

        my_render.enabled = is_active;

        player_close = Physics2D.OverlapCircle(transform.position, range, player_layer);

        if (player_close && !interacted_with && is_active)
        {
            prompt.SetActive(true);
        } else
        {
            prompt.SetActive(false);
        }

        if (player_close && !interacted_with && Input.GetKeyDown(KeyCode.E) && is_active)
        {
            interacted_with = true;
            Mind.para_progress = new_level;
            the_sys.data_PROGRESS_para = new_level;
            the_sys.SaveSystem_SAVE();
        }

    }
}
