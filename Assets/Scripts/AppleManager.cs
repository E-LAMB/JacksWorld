using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleManager : MonoBehaviour
{

    public int apples_collected;

    public GameObject old_amara;
    public GameObject new_amara;

    public float objective_time;
    public NPC_Script amara_npc;
    public bool spoke_to_npc;

    public Image image_apple_1;
    public Image image_apple_2;
    public Image image_apple_3;

    // public GameObject exit_door;

    private Vector4 off_col;
    private Vector4 on_col;

    // Start is called before the first frame update
    void Start()
    {
        off_col = new Vector4 (0.2f, 0.2f, 0.2f, 1f);
        on_col = new Vector4 (1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (amara_npc.dia_state > 3)
        {
            spoke_to_npc = true;
        }

        if (spoke_to_npc)
        {
            if (apples_collected > 0) {image_apple_1.color = on_col;} else {image_apple_1.color = off_col;}
            if (apples_collected > 1) {image_apple_2.color = on_col;} else {image_apple_2.color = off_col;}
            if (apples_collected > 2) {image_apple_3.color = on_col;} else {image_apple_3.color = off_col;}
        }

        if (spoke_to_npc && objective_time < 3f)
        {
            image_apple_1.enabled = true;
            image_apple_2.enabled = true;
            image_apple_3.enabled = true;
        } else
        {
            image_apple_1.enabled = false;
            image_apple_2.enabled = false;
            image_apple_3.enabled = false;
        }

        if (apples_collected == 3)
        {
            objective_time += Time.deltaTime;
            old_amara.SetActive(false);
            new_amara.SetActive(true);
            // exit_door.SetActive(true);
        }
    }
}
