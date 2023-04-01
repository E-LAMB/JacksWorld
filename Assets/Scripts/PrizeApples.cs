using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeApples : MonoBehaviour
{

    public LayerMask player_layer;
    public bool player_is_close;

    public GameObject my_prompt;

    public AppleManager my_manager;

    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_is_close = Physics2D.OverlapCircle(transform.position, 0.5f, player_layer);
        my_prompt.SetActive(player_is_close);

        if (player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            my_manager.apples_collected += 1;
            self.SetActive(false);
        }
    }

}
