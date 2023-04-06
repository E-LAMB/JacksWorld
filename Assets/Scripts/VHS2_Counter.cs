using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS2_Counter : MonoBehaviour
{

    public int letters_placed;

    public int letters_needed;

    public bool puzzle_completed;

    public Camera main_cam;
    public Transform main_cam_trans;

    public float cutscene_time;

    public AnimationCurve camera_size;
    public AnimationCurve camera_rotation_z;

    public float cam_rot;

    public VHS_Exit exit;

    public GameObject flash;
    public bool flash_bool;

    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        flash_bool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (letters_placed == letters_needed)
        {
            puzzle_completed = true;
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
