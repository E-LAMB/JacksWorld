using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS2_Counter : MonoBehaviour
{

    public int letters_placed;

    public int letters_needed;

    public bool puzzle_completed;

    public GameObject ambush;

    public Camera main_cam;
    public Transform main_cam_trans;

    public float cutscene_time;

    public AnimationCurve camera_size;
    public AnimationCurve camera_rotation_z;

    public float cam_rot;

    public VHS_Exit exit;

    public GameObject flash;
    public bool flash_bool;

    public int remaining_letters;
    public GameObject[] letter_selection;
    public GameObject selected_letter;
    public bool selected_the_letter;
    public int guesses_made;

    public void AddMore()
    {
        guesses_made = 0;
        selected_the_letter = false;
        if (remaining_letters != 0)
        {
            remaining_letters -= 1;
            selected_letter = null;

            while (!selected_the_letter && guesses_made < 120)
            {
                selected_letter = letter_selection[Random.Range(0, letter_selection.Length)];
                guesses_made += 1;
                if (!selected_letter.activeInHierarchy)
                {
                    selected_the_letter = true;
                }
            }
            
            selected_letter.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        flash_bool = false;
        AddMore();
        AddMore();
        AddMore();
    }

    // Update is called once per frame
    void Update()
    {
        if (letters_placed == letters_needed && puzzle_completed == false)
        {
            puzzle_completed = true;
            ambush.SetActive(true);
        }

        if (puzzle_completed)
        {
            cutscene_time += Time.deltaTime;
        }

        if (cutscene_time > 5f)
        {
            if (Random.Range(1,4) == 1)
            {
                flash_bool = !flash_bool;
                flash.SetActive(flash_bool);
            }
        }

        main_cam.orthographicSize = camera_size.Evaluate(cutscene_time);
        cam_rot = camera_rotation_z.Evaluate(cutscene_time);

        main_cam_trans.localRotation = Quaternion.Euler(0f,0f,cam_rot);

        if (cutscene_time > 6.5f)
        {
            exit.switch_scenes();
        }

    }
}
