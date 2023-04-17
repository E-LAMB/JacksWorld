using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Lift : MonoBehaviour
{

    public bool is_activated;

    public LayerMask player_layer;
    public bool player_is_close;

    public bool show_prompt;
    public GameObject my_prompt;

    public Transform warp;
    public Transform player;

    public SpriteRenderer my_button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_is_close = Physics2D.OverlapCircle(transform.position, 2f, player_layer);

        if (is_activated)
        {
            my_button.color = new Vector4(1f,1f,1f,1f);
        } else
        {
            my_button.color = new Vector4(0.7f,0.7f,0.7f,1f);
        }

        if (player_is_close && is_activated)
        {
            show_prompt = true;
        } else
        {
            show_prompt = false;
        }

        my_prompt.SetActive(show_prompt);

        if (player_is_close && is_activated && Input.GetKeyDown(KeyCode.E))
        {
            player.position = warp.position;
        }

    }
}
