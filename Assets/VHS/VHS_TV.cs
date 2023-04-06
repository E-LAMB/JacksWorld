using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS_TV : MonoBehaviour
{

    public string corresponding_tape;

    public SpriteRenderer static_back;
    public float static_value;

    public Animator my_anim;

    public bool has_tape;
    public bool viewed_tape;

    public GameObject dark;

    public bool player_is_close;
    public LayerMask player_layer;

    public GameObject prompt;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Mind.apple_vhs);
        Debug.Log(Mind.seen_apple_vhs);
    }

    void ViewVHS()
    {
        if (corresponding_tape == "apple") {UnityEngine.SceneManagement.SceneManager.LoadScene(15);}
        if (corresponding_tape == "flower") {UnityEngine.SceneManagement.SceneManager.LoadScene(16);}
        if (corresponding_tape == "mines") {UnityEngine.SceneManagement.SceneManager.LoadScene(17);}
        if (corresponding_tape == "orange") {UnityEngine.SceneManagement.SceneManager.LoadScene(18);}
        if (corresponding_tape == "hub") {UnityEngine.SceneManagement.SceneManager.LoadScene(19);}
    }

    // Update is called once per frame
    void Update()
    {

        has_tape = false;
        if (Mind.apple_vhs && corresponding_tape == "apple") {has_tape = true;}
        if (Mind.flower_vhs && corresponding_tape == "flower") {has_tape = true;}
        if (Mind.mines_vhs && corresponding_tape == "mines") {has_tape = true;}
        if (Mind.orange_vhs && corresponding_tape == "orange") {has_tape = true;}
        if (Mind.hub_vhs && corresponding_tape == "hub") {has_tape = true;}

        viewed_tape = false;
        if (Mind.seen_apple_vhs && corresponding_tape == "apple") {viewed_tape = true;}
        if (Mind.seen_flower_vhs && corresponding_tape == "flower") {viewed_tape = true;}
        if (Mind.seen_mines_vhs && corresponding_tape == "mines") {viewed_tape = true;}
        if (Mind.seen_orange_vhs && corresponding_tape == "orange") {viewed_tape = true;}
        if (Mind.seen_hub_vhs && corresponding_tape == "hub") {viewed_tape = true;}

        dark.SetActive(viewed_tape);

        my_anim.SetBool("HasTape",has_tape);

        static_value = Random.Range(0f,1f);
        static_back.color = new Vector4 (static_value, static_value, static_value, 1);

        if (has_tape && !viewed_tape)
        {

            player_is_close = Physics2D.OverlapCircle(transform.position, 2f, player_layer);

            if (player_is_close)
            {
                prompt.SetActive(true);
            } else
            {
                prompt.SetActive(false);
            }

            // prompt.SetActive(player_is_close);

            if (player_is_close && Input.GetKeyDown(KeyCode.E))
            {
                ViewVHS();
            }

        } else
        {
            prompt.SetActive(false);
        }
    }
}
