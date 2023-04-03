using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSwitches : MonoBehaviour
{
    
    public OrangeMinigame my_minigame_manager;
    public SwivelRotator my_rotator;
    public float my_angle;

    public bool can_interact;

    public bool player_is_close;
    public LayerMask player_layer;

    public GameObject my_prompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (my_minigame_manager.minigame_active)
        {

            player_is_close = Physics2D.OverlapCircle(transform.position, 1f, player_layer);

            can_interact = false;
            if (player_is_close && my_rotator.ideal_angle != my_angle)
            {
                can_interact = true;
            }

            if (player_is_close && my_rotator.ideal_angle != my_angle && Input.GetKeyDown(KeyCode.E))
            {
                my_rotator.ideal_angle = my_angle;
            }

            my_prompt.SetActive(can_interact);

        } else
        {
            my_prompt.SetActive(false);
        }
    }
}
