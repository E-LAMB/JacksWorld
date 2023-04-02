using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLever_Lift : MonoBehaviour
{

    public int dia_state;
    // 0 = Inactive
    // 1 = Waiting
    // 2 = Talking (key still down)
    // 3 = Can conclude
    // 4 = Concluded

    public LayerMask player_layer;
    public bool player_is_close;

    public GameObject my_prompt;

    public string my_name;

    public Subtitle subtitle_system;

    [TextArea(5,20)]
    public string my_text = "";

    public bool show_prompt;

    public Button_Lift lift_1;
    public Button_Lift lift_2; 

    public bool should_activate_turner;
    public Turner turner;

    public GameObject deactivated;
    public GameObject activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        player_is_close = Physics2D.OverlapCircle(transform.position, 2f, player_layer);

        if (player_is_close && dia_state == 1)
        {
            show_prompt = true;
        } else
        {
            show_prompt = false;
        }

        my_prompt.SetActive(show_prompt);

        if (dia_state == 1 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            dia_state = 2;
            Mind.player_in_control = false;
            deactivated.SetActive(false);
            activated.SetActive(true);
            subtitle_system.ShowDialouge(my_text,my_name);
        }

        if (dia_state == 2 && player_is_close && Input.GetKeyUp(KeyCode.E))
        {
            dia_state = 3;
            Debug.Log(dia_state);
        }

        if (dia_state == 3 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            dia_state = 4;
            Mind.player_in_control = true;
            subtitle_system.ConcludeDialouge();
            lift_1.is_activated = true;
            lift_2.is_activated = true;
            if (should_activate_turner)
            {
                turner.currently_active = true;
            }
        }

        if (dia_state == 4)
        {
            GetComponent<PowerLever_Lift>().enabled = false;
        }

    }
}