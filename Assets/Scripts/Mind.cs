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

    public static bool has_done_startup;
    public static string actual_save_path;

    public static bool seen_apple_vhs;
    public static bool seen_flower_vhs;
    public static bool seen_mines_vhs;
    public static bool seen_orange_vhs;
    public static bool seen_hub_vhs;

    public static bool seen_good_ending;
    public static bool seen_bad_ending;

    public static int current_save_point;
    public static int max_save_point;

    public static bool player_in_control;

    public static float prompt_size = 0.3f;
    public static float save_icon_time;

}
