using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS_Exit : MonoBehaviour
{

    public int after_hub;

    public int which_was_seen;

    public SaveSystem the_sys;

    public void switch_scenes()
    {
        if (which_was_seen == 1) {Mind.seen_apple_vhs = true;}
        if (which_was_seen == 2) {Mind.seen_flower_vhs = true;}
        if (which_was_seen == 3) {Mind.seen_mines_vhs = true;}
        if (which_was_seen == 4) {Mind.seen_orange_vhs = true;}
        if (which_was_seen == 5) {Mind.seen_hub_vhs = true;}

        the_sys.SaveSystem_SAVE();

        if (Mind.return_to_vhs_menu)
        {
            Mind.return_to_vhs_menu = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(29);
        } else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(after_hub);
        }
    }

}
