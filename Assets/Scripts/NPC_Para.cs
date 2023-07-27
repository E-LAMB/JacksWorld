using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Para : MonoBehaviour
{

    public int dia_state;
    // 0 = Inactive
    // 1 = Waiting
    // 2 = Talking (key still down)
    // 3 = Can conclude
    // 4 = Concluded

    public LayerMask player_layer;
    public bool player_is_close;

    public int scene_to_warp;

    public GameObject my_prompt;

    public string my_name;

    public Subtitle subtitle_system;

    [TextArea(5,20)]
    public string my_text = "";

    [TextArea(5,20)]
    public string my_text_2 = "";

    public bool show_prompt;

    public string special_range;

    public GameObject jack_possessed;

    float d_range = 2f;
    public float exit_time;

    public GameObject blackness;
    
    public bool show_blackness;

    // Start is called before the first frame update
    void Start()
    {
        if (special_range == "door")
        {
            d_range = 1f;
        }
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
            dia_state = 2;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text,my_name);
        }

        if (dia_state == 2 && Input.GetKeyUp(KeyCode.E))
        {
            dia_state = 3;
            Debug.Log(dia_state);
        }

        if (dia_state == 3 && player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            dia_state = 4;
            Mind.player_in_control = false;
            subtitle_system.ShowDialouge(my_text_2,my_name);
        }

        if (dia_state == 4 && Input.GetKeyUp(KeyCode.E))
        {
            dia_state = 5;
            Debug.Log(dia_state);
        }

        if (dia_state == 5 && Input.GetKeyDown(KeyCode.E))
        {
            dia_state = 6;
            blackness.SetActive(true);
        }

        if (dia_state == 6)
        {
            exit_time += Time.deltaTime;
        }

        if (dia_state == 6 && exit_time > 1f)
        {
            jack_possessed.SetActive(true);
            blackness.SetActive(false);
            dia_state = 7;
            exit_time = 0f;
        }

        if (dia_state == 7)
        {
            if (Random.Range(0,3) == 1)
            {
                show_blackness = !show_blackness;
                blackness.SetActive(show_blackness);
            }
        }

        if (dia_state == 7)
        {
            exit_time += Time.deltaTime;
            if (exit_time > 4f)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_warp);
            }
        }

    }
}
