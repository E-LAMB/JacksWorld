using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Glitch : MonoBehaviour
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

    public PlayerController player_script; // dashing_unlocked

    public bool show_prompt;

    public GameObject signage;

    public GameObject new_grim;
    public GameObject old_grim;

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
            player_script.dashing_unlocked = true;
            signage.SetActive(true);
            old_grim.SetActive(false);
            new_grim.SetActive(true);
        }

        if (dia_state == 4)
        {
            GetComponent<NPC_Glitch>().enabled = false;
        }

    }
}
