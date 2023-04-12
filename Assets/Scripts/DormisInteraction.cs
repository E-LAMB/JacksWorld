using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormisInteraction : MonoBehaviour
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
    public string[] my_text;

    public bool show_prompt;

    public string special_range;

    float d_range = 2f;

    public SaveSystem the_sys;
    public int deposited_tapes;
    public bool tapes_counted;

    // Start is called before the first frame update
    void Start()
    {
        if (special_range == "door")
        {
            d_range = 1f;
        }
        deposited_tapes = 0;
    }

    // Update is called once per frame
    void Update()
    {

        player_is_close = Physics2D.OverlapCircle(transform.position, d_range, player_layer);

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
            dia_state += 1;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text[1],my_name);
            if (the_sys.data_VHS_1 == 2 && !tapes_counted) {deposited_tapes += 1;}
            if (the_sys.data_VHS_2 == 2 && !tapes_counted) {deposited_tapes += 1;}
            if (the_sys.data_VHS_3 == 2 && !tapes_counted) {deposited_tapes += 1;}
            if (the_sys.data_VHS_4 == 2 && !tapes_counted) {deposited_tapes += 1;}
            if (the_sys.data_VHS_5 == 2 && !tapes_counted) {deposited_tapes += 1;}
            tapes_counted = true;
        }

        if (dia_state == 2 && Input.GetKeyUp(KeyCode.E))
        {
            dia_state += 1;
            Debug.Log(dia_state);
        }

        if (dia_state == 3 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {

            string new_text;

            new_text = "Grim would have you find a way out, I would too. But that's stressful for a boy like you. ";

            if (deposited_tapes == 0)
            {
                new_text += "After all, You've not even deposited a single tape. Are you scared what they may hold?";

            } else if (deposited_tapes == 5)
            {
                new_text += "You've seen the tapes, You know you're not safe even once you do get it back.";
            } else
            {
                new_text += "Although you have started to watch them haven't you? It's good to know I got every detail right.";
            }
            
            my_text[3] = new_text;

            dia_state += 1;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text[2],my_name);
        }

        if (dia_state == 4 && Input.GetKeyUp(KeyCode.E))
        {
            dia_state += 1;
            Debug.Log(dia_state);
        }

        if (dia_state == 5 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            dia_state += 1;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text[3],my_name);
        }

        if (dia_state == 6 && Input.GetKeyUp(KeyCode.E))
        {
            dia_state += 1;
            Debug.Log(dia_state);
        }

        if (dia_state == 7 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            dia_state += 1;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text[4],my_name);
        }

        if (dia_state == 8 && Input.GetKeyUp(KeyCode.E))
        {
            dia_state += 1;
            Debug.Log(dia_state);
        }




        if (dia_state == 9 && Input.GetKeyDown(KeyCode.E))
        {
            dia_state = 10;
            Mind.player_in_control = true;
            subtitle_system.ConcludeDialouge();
        }

        if (dia_state == 10)
        {
            GetComponent<DormisInteraction>().enabled = false;
        }

    }
}
