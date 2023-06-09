using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNPC : MonoBehaviour
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

    public BombCounter my_counter;

    public int my_id;

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

        if (dia_state > 1)
        {
            player_is_close = true;
        }

        if (dia_state == 1 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            dia_state = 2;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text,my_name);

            if (my_id == 1) {my_counter.icon_bomb_1 = true;}
            if (my_id == 2) {my_counter.icon_bomb_2 = true;}
            if (my_id == 3) {my_counter.icon_bomb_3 = true;}
            if (my_id == 4) {my_counter.icon_bomb_4 = true;}

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
            my_counter.interactions += 1;
        }

        if (dia_state == 4)
        {
            GetComponent<BombNPC>().enabled = false;
        }

    }
}
