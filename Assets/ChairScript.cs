using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : MonoBehaviour
{

    public SpriteRenderer the_player;

    public GameObject chair_empty;
    public GameObject chair_full;

    public DormisInteraction dormis;

    public bool has_talked;
    public bool is_close;
    public LayerMask player;
    public GameObject prompt;
    public bool is_sitting;

    public float subtitle_time;
    public Subtitle sub_sys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dormis.dia_state > 9)
        {
            has_talked = true;
        }

        is_close = Physics2D.OverlapCircle(transform.position, 2f, player);

        if (is_close && has_talked && !is_sitting)
        {
            prompt.SetActive(true);
        } else
        {
            prompt.SetActive(false);
        }

        if (has_talked && is_close && Input.GetKeyDown(KeyCode.E) && !is_sitting)
        {
            is_sitting = true;
        }

        if (subtitle_time > 7f)
        {
            sub_sys.ShowDialouge("I hope you are enjoying that, You can stay with me as long as you want Okay? You're safe here.", "Dormis");
        }

        if (is_sitting)
        {
            the_player.enabled = false;
            chair_empty.SetActive(false);
            chair_full.SetActive(true);
            Mind.player_in_control = false;
            subtitle_time += Time.deltaTime;
        }
    }
}
