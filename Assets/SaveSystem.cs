using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{

    [Header("Scene Specific Data")]

    public int current_location_save_ID;
    public bool should_Autosave;

    public bool should_reload;

    public string ending_gotten;

    public bool AutosaveOneSafety;

    // --- Data Extraction --- //

    [Header("Extracted Data (Arrays)")]

    public string[] collective_extraction_wide;
    public string[] collective_extraction_VHS;
    public string[] collective_extraction_PROGRESS;
    public string[] collective_extraction_ENDING;

    [Header("Extracted Data (Chars)")]
    public char char_widesplit;
    public char char_smallsplit;

    // Example:
    // 0.0.0.0.0/5.5/1.1

    [Header("Extracted Data (Individual)")]
    public int data_VHS_1;
    public int data_VHS_2;
    public int data_VHS_3;
    public int data_VHS_4;
    public int data_VHS_5;

    // 0 = Not Collected
    // 1 = Collected
    // 2 = Played Tape

    public int data_PROGRESS_max;
    public int data_PROGRESS_current;

    public int data_ENDING_good;
    public int data_ENDING_bad;

    // 0 = Not Seen
    // 1 = Seen

    // Private Variables

    private bool file_preexisted;

    public void SaveSystem_RESET()
    {
        string content;

        content = "";

        // VHS

        content += "0.0.0.0.0/";

        // PROGRESS

        content += "0.0/";

        // ENDING

        content += "0.0";

        // ----- Data Gets Saved ----- //

        StreamWriter writer = new StreamWriter(Mind.actual_save_path, false);
        writer.Write(content);
        Debug.Log(content);
        writer.Close();

    }

    public void SaveSystem_SAVE()
    {
        string content;

        content = "";

        // VHS

        if (Mind.seen_apple_vhs)
        {
            content += "2" + ".";
        } else if (Mind.apple_vhs)
        {
            content += "1" + ".";
        } else
        {
            content += "0" + ".";
        }

        if (Mind.seen_flower_vhs)
        {
            content += "2" + ".";
        } else if (Mind.flower_vhs)
        {
            content += "1" + ".";
        } else
        {
            content += "0" + ".";
        }

        if (Mind.seen_mines_vhs)
        {
            content += "2" + ".";
        } else if (Mind.mines_vhs)
        {
            content += "1" + ".";
        } else
        {
            content += "0" + ".";
        }

        if (Mind.seen_orange_vhs)
        {
            content += "2" + ".";
        } else if (Mind.orange_vhs)
        {
            content += "1" + ".";
        } else
        {
            content += "0" + ".";
        }

        if (Mind.seen_hub_vhs)
        {
            content += "2" + "/";
        } else if (Mind.hub_vhs)
        {
            content += "1" + "/";
        } else
        {
            content += "0" + "/";
        }

        // PROGRESS

        data_PROGRESS_max = Mind.max_save_point;

        Debug.Log("Running Comparison");
        Debug.Log(current_location_save_ID + " + " + data_PROGRESS_max);

        if (current_location_save_ID > data_PROGRESS_max)
        {
            content += current_location_save_ID.ToString() + ".";
        } else
        {
            content += data_PROGRESS_max.ToString() + ".";
        }

        content += current_location_save_ID.ToString() + "/";

        // ENDING

        content += Mind.seen_good_ending.ToString() + ".";
        content += Mind.seen_bad_ending.ToString();

        // ----- Data Gets Saved ----- //

        StreamWriter writer = new StreamWriter(Mind.actual_save_path, false);
        writer.Write(content);
        Debug.Log(content);
        writer.Close();

    }

    public void SaveSystem_LOAD()
    {
        
        StreamReader reader = new StreamReader(Mind.actual_save_path);
        string content;
        content = reader.ReadToEnd(); // Reads the content in the file
        reader.Close();
        Debug.Log(content); 

        // Separating The Data Out

        collective_extraction_wide = content.Split(char_widesplit);
        collective_extraction_VHS = collective_extraction_wide[0].Split(char_smallsplit);
        collective_extraction_PROGRESS = collective_extraction_wide[1].Split(char_smallsplit);
        collective_extraction_ENDING = collective_extraction_wide[2].Split(char_smallsplit);

        // Assigning Data to Variables (VHS)

        if (collective_extraction_VHS[0] == "0")
        {
            Mind.apple_vhs = false;
            Mind.seen_apple_vhs = false;
            data_VHS_1 = 0;

        } else if (collective_extraction_VHS[0] == "1")
        {
            Mind.apple_vhs = true;
            Mind.seen_apple_vhs = false;
            data_VHS_1 = 1;

        } else if (collective_extraction_VHS [0] == "2")
        {
            Mind.apple_vhs = true;
            Mind.seen_apple_vhs = true;
            data_VHS_1 = 2;
        }

        if (collective_extraction_VHS[1] == "0")
        {
            Mind.flower_vhs = false;
            Mind.seen_flower_vhs = false;
            data_VHS_2 = 0;

        } else if (collective_extraction_VHS[1] == "1")
        {
            Mind.flower_vhs = true;
            Mind.seen_flower_vhs = false;
            data_VHS_2 = 1;

        } else if (collective_extraction_VHS [1] == "2")
        {
            Mind.flower_vhs = true;
            Mind.seen_flower_vhs = true;
            data_VHS_2 = 2;
        }

        if (collective_extraction_VHS[2] == "0")
        {
            Mind.mines_vhs = false;
            Mind.seen_mines_vhs = false;
            data_VHS_3 = 0;

        } else if (collective_extraction_VHS[2] == "1")
        {
            Mind.mines_vhs = true;
            Mind.seen_mines_vhs = false;
            data_VHS_3 = 1;

        } else if (collective_extraction_VHS [2] == "2")
        {
            Mind.mines_vhs = true;
            Mind.seen_mines_vhs = true;
            data_VHS_3 = 2;
        }

        if (collective_extraction_VHS[3] == "0")
        {
            Mind.orange_vhs = false;
            Mind.seen_orange_vhs = false;
            data_VHS_4 = 0;

        } else if (collective_extraction_VHS[3] == "1")
        {
            Mind.orange_vhs = true;
            Mind.seen_orange_vhs = false;
            data_VHS_4 = 1;

        } else if (collective_extraction_VHS [3] == "2")
        {
            Mind.orange_vhs = true;
            Mind.seen_orange_vhs = true;
            data_VHS_4 = 2;
        }

        if (collective_extraction_VHS[4] == "0")
        {
            Mind.hub_vhs = false;
            Mind.seen_hub_vhs = false;
            data_VHS_5 = 0;

        } else if (collective_extraction_VHS[4] == "1")
        {
            Mind.hub_vhs = true;
            Mind.seen_hub_vhs = false;
            data_VHS_5 = 1;

        } else if (collective_extraction_VHS [4] == "2")
        {
            Mind.hub_vhs = true;
            Mind.seen_hub_vhs = true;
            data_VHS_5 = 2;
        }

        // Assigning Data to Variables (PROGRESS)

        // 0 = Hasn't played the game
        // 1 = Hub 1
        // 2 = Applefarm
        // 3 = Hub2
        // 4 = Flowerfield
        // 5 = Hub3
        // 6 = Mines
        // 7 = Hub4
        // 8 = Orange Outside
        // 9 = Orange Minigame
        // 10 = Out Of Bounds
        // 11 = Applefarm Revisit
        // 12 = Hub5
        // 13 = Home

        Mind.max_save_point = int.Parse(collective_extraction_PROGRESS[0]);
        Mind.current_save_point = int.Parse(collective_extraction_PROGRESS[1]);

        data_PROGRESS_max = int.Parse(collective_extraction_PROGRESS[0]);
        data_PROGRESS_current = int.Parse(collective_extraction_PROGRESS[1]);

        // Assigning Data to Variables (ENDINGS)

        if (collective_extraction_ENDING[0] == "1")
        {
            Mind.seen_good_ending = true;
            data_ENDING_good = 0;
        } else
        {
            Mind.seen_good_ending = false;
            data_ENDING_good = 1;
        }

        if (collective_extraction_ENDING[1] == "1")
        {
            Mind.seen_bad_ending = true;
            data_ENDING_bad = 0;
        } else
        {
            Mind.seen_bad_ending = false;
            data_ENDING_bad = 1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (AutosaveOneSafety)
        {
            data_PROGRESS_max = Mind.max_save_point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Mind.has_done_startup)
        {
            Mind.has_done_startup = true;

            Mind.actual_save_path = Application.persistentDataPath + "/JackMemory.txt";

            Debug.Log(Mind.actual_save_path);

            file_preexisted = File.Exists(Mind.actual_save_path);

            if (!file_preexisted)
            {
                File.Create(Mind.actual_save_path);
                SaveSystem_RESET();
                SaveSystem_LOAD();
            } else
            {
                SaveSystem_LOAD();
            }

        }

        if (should_reload)
        {
            should_reload = false;
            Debug.Log("Checking MAX and CURRENT (as reload)");
            Debug.Log(Mind.max_save_point);
            Debug.Log(Mind.current_save_point);
            SaveSystem_LOAD();
            Debug.Log("Checking MAX and CURRENT (after the reload)");
            Debug.Log(Mind.max_save_point);
            Debug.Log(Mind.current_save_point);
        }

        if (should_Autosave)
        {
            Mind.current_save_point = current_location_save_ID;
            Debug.Log("Checking MAX and CURRENT (as auto)");
            Debug.Log(Mind.max_save_point);
            Debug.Log(Mind.current_save_point);
            if (ending_gotten == "Good") {Mind.seen_good_ending = true;}
            if (ending_gotten == "Bad") {Mind.seen_bad_ending = true;}
            SaveSystem_SAVE();
            should_Autosave = false;
        }

    }
}
