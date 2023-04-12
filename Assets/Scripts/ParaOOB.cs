using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaOOB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool has_checked_for_ending;
    public float check_time;
    public SaveSystem the_sys;

    // Update is called once per frame
    void Update()
    {
        check_time += Time.deltaTime;
        if (the_sys.data_PROGRESS_para == 0 && !has_checked_for_ending && check_time > 1f)
        {
            has_checked_for_ending = true;
            bool seen_an_ending = false;
            if (the_sys.data_ENDING_good != 0) {seen_an_ending = true;}
            if (the_sys.data_ENDING_bad != 0) {seen_an_ending = true;}
            if (the_sys.data_ENDING_safe != 0) {seen_an_ending = true;}
            if (the_sys.data_ENDING_stolen != 0) {seen_an_ending = true;}
            if (seen_an_ending)
            {
                the_sys.data_PROGRESS_para = 1;
                Mind.para_progress = 1;
                the_sys.SaveSystem_SAVE();
            }
        }

        if (check_time > 3f)
        {
            gameObject.GetComponent<ParaOOB>().enabled = false;
        }
    }
}
