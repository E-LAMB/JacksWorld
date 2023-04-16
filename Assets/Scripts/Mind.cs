using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mind 
{

    public static bool apple_vhs;
    public static bool flower_vhs;
    public static bool mines_vhs;
    public static bool orange_vhs;
    public static bool hub_vhs;

    // public static int current_track;
    // 0 = None
    // 1 = Apples - Mines
    // 2 = Mines - OOB
    // 3 = OOB - Applefarm RV

    public static float volume;

    public static bool has_done_startup;
    public static string actual_save_path;

    public static bool seen_apple_vhs;
    public static bool seen_flower_vhs;
    public static bool seen_mines_vhs;
    public static bool seen_orange_vhs;
    public static bool seen_hub_vhs;

    public static bool return_to_vhs_menu;

    public static bool seen_good_ending;
    public static bool seen_bad_ending;
    public static bool seen_safe_ending;
    public static bool seen_stolen_ending;

    public static int para_progress;
    // 0 = Has gotten no endings
    // 1 = Has gotten an ending but has not found the crown
    // 2 = Found crown in APPLEFARM revisit 
    // 3 = Has revived Para
    // 4 = Has gotten Para ending

    public static int current_save_point;
    public static int max_save_point;

    public static bool player_in_control;

    public static float prompt_size = 0.3f;

}
