using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCounter : MonoBehaviour
{

    public int interactions;

    public GameObject old_amara;
    public GameObject new_amara;

    public GameObject exit_door;

    public Transform big_door;

    public NPC_Script little_girl;

    public bool talked_to_little_girl;

    public bool icon_bomb_1;
    public bool icon_bomb_2;
    public bool icon_bomb_3;
    public bool icon_bomb_4;

    public Image bomb_1_icon;
    public Image bomb_2_icon;
    public Image bomb_3_icon;
    public Image bomb_4_icon;

    private Vector4 off_col;
    private Vector4 on_col;

    public float time_since_completion;

    // Start is called before the first frame update
    void Start()
    {
        off_col = new Vector4 (0.2f, 0.2f, 0.2f, 1f);
        on_col = new Vector4 (1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (little_girl.dia_state > 3)
        {
            talked_to_little_girl = true;
        }

        if (talked_to_little_girl)
        {
            Vector3 new_position = big_door.position;
            new_position.y += Time.deltaTime * 0.55f;
            big_door.position = new_position;
        }

        if (talked_to_little_girl && time_since_completion < 3f)
        {
            bomb_1_icon.enabled = true;
            bomb_2_icon.enabled = true;
            bomb_3_icon.enabled = true;
            bomb_4_icon.enabled = true;

            if (!icon_bomb_1) {bomb_1_icon.color = off_col;} else {bomb_1_icon.color = on_col;}
            if (!icon_bomb_2) {bomb_2_icon.color = off_col;} else {bomb_2_icon.color = on_col;}
            if (!icon_bomb_3) {bomb_3_icon.color = off_col;} else {bomb_3_icon.color = on_col;}
            if (!icon_bomb_4) {bomb_4_icon.color = off_col;} else {bomb_4_icon.color = on_col;}

        } else
        {
            bomb_1_icon.enabled = false;
            bomb_2_icon.enabled = false;
            bomb_3_icon.enabled = false;
            bomb_4_icon.enabled = false;
        }
                
        if (interactions == 4)
        {
            time_since_completion += Time.deltaTime;
            old_amara.SetActive(false);
            new_amara.SetActive(true);
            exit_door.SetActive(true);
        }
    }
}
