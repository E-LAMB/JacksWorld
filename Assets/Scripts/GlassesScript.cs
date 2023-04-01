using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesScript : MonoBehaviour
{

    public LayerMask player_layer;
    public bool player_is_close;

    public GameObject my_prompt;

    public GameObject myself;
    public GameObject old_sunny;
    public GameObject new_sunny;
    public GameObject my_door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollection()
    {

    }

    // Update is called once per frame
    void Update()
    {

        player_is_close = Physics2D.OverlapCircle(transform.position, 2f, player_layer);

        my_prompt.SetActive(player_is_close);

        if (player_is_close && Input.GetKeyDown(KeyCode.E))
        {

            old_sunny.SetActive(false);
            new_sunny.SetActive(true);
            my_door.SetActive(true);
            myself.SetActive(false);

        }

    }
}
