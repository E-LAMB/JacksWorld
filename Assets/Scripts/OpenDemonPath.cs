using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDemonPath : MonoBehaviour
{

    public bool seen_an_ending;
    public SaveSystem ss_l;

    public GameObject block;
    public GameObject triggers;

    public bool should_do_block = true;
    public bool should_do_triggers = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seen_an_ending = false;
        if (ss_l.data_ENDING_good != 0) {seen_an_ending = true;}
        if (ss_l.data_ENDING_bad != 0) {seen_an_ending = true;}
        if (ss_l.data_ENDING_safe != 0) {seen_an_ending = true;}
        if (ss_l.data_ENDING_stolen != 0) {seen_an_ending = true;}
    
        if (should_do_block) {block.SetActive(!seen_an_ending);}
        if (should_do_triggers) {triggers.SetActive(seen_an_ending);}
    }
}
