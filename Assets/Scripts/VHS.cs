using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS : MonoBehaviour
{

    public int scene_to_warp;

    public LayerMask player_layer;
    public bool player_is_close;

    public GameObject my_prompt;

    public int vhs_id;

    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollection()
    {
        if (vhs_id == 1) {Mind.apple_vhs = true;}
        if (vhs_id == 2) {Mind.flower_vhs = true;}
        if (vhs_id == 3) {Mind.mines_vhs = true;}
        if (vhs_id == 4) {Mind.orange_vhs = true;}
        if (vhs_id == 5) {Mind.oob_vhs = true;}
    }

    // Update is called once per frame
    void Update()
    {

        if (Mind.apple_vhs && vhs_id == 1) {self.SetActive(false);}
        if (Mind.flower_vhs && vhs_id == 2) {self.SetActive(false);}
        if (Mind.mines_vhs && vhs_id == 3) {self.SetActive(false);}
        if (Mind.orange_vhs && vhs_id == 4) {self.SetActive(false);}
        if (Mind.oob_vhs && vhs_id == 5) {self.SetActive(false);}

        player_is_close = Physics2D.OverlapCircle(transform.position, 0.5f, player_layer);
        my_prompt.SetActive(player_is_close);

        if (player_is_close && Input.GetKeyDown(KeyCode.E))
        {
            OnCollection();
        }

    }
}
