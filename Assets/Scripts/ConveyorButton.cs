using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorButton : MonoBehaviour
{

    public bool conveyor_active;

    public TrapdoorScript my_trapdoor;

    public bool player_is_close;
    public GameObject prompt;
    public LayerMask player_layer;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_is_close = Physics2D.OverlapCircle(transform.position, 1f, player_layer);

        if (player_is_close && Input.GetKeyDown(KeyCode.E) && timer < 0f)
        {
            timer = 3f;
        }

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
            conveyor_active = true;
        } else
        {
            conveyor_active = false;
        }

        my_trapdoor.currently_active = conveyor_active;

        if (timer >= 0f)
        {
            player_is_close = false;
        }

        prompt.SetActive(player_is_close);
    }
}
