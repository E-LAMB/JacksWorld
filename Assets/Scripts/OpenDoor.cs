using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public int scene_to_warp;

    public LayerMask player_layer;
    public bool player_is_close;

    public GameObject my_prompt;

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
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_warp);
        }

    }
}
