using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaShrine : MonoBehaviour
{

    public SaveSystem the_sys;

    public int new_level;

    public GameObject prompt;
    
    public bool player_close;
    public bool interacted_with;

    public bool is_active;

    public GameObject no_crown;
    public GameObject has_crown;

    public float range;
    public LayerMask player_layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (the_sys.data_PROGRESS_para > 1)
        {
            is_active = true;
        } else
        {
            is_active = false;
        }

        if (the_sys.data_PROGRESS_para > 2)
        {
            interacted_with = true;
        }

        player_close = Physics2D.OverlapCircle(transform.position, range, player_layer);

        if (player_close && !interacted_with && is_active)
        {
            prompt.SetActive(true);
        } else
        {
            prompt.SetActive(false);
        }

        if (!interacted_with && is_active)
        {
            no_crown.SetActive(true);
        }

        if (interacted_with)
        {
            has_crown.SetActive(true);
            no_crown.SetActive(false);
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

