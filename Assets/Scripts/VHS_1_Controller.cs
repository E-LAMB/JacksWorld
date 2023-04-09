using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VHS_1_Controller : MonoBehaviour
{

    public int current_stage;
    public int end_stage;

    public float out_timer;
    public VHS_Exit exit;

    // 108 = Right Colour (108 / 255)
    // 200 = New Colour (200 / 255)

    // TextMeshPro
    public TextMeshProUGUI subtitles;

    [TextArea(2,2)]
    public string[] subtitle_list;

    public float cam_timer;
    public int cam_threshold;
    public AnimationCurve cam_size;
    public Transform new_location;
    public Vector3 cam_target;

    public Transform my_camera_trans;
    public Camera my_camera_cam;

    public GameObject flash;

    public float speed;

    public bool flash_state;

    // Start is called before the first frame update
    void Start()
    {
        subtitles.text = subtitle_list[current_stage];
        // cam_target = my_camera_trans.position;
        flash.SetActive(false);
        flash_state = false;
    }

    // Update is called once per frame
    void Update()
    {
        subtitles.text = subtitle_list[current_stage];

        if (cam_threshold <= current_stage)
        {
            cam_timer += Time.deltaTime;
            my_camera_cam.orthographicSize = cam_size.Evaluate(cam_timer);
            cam_target = new_location.position;
        }

        Vector3 desiredPosition = cam_target;
        Vector3 smoothedPosition = Vector3.Lerp(my_camera_trans.position, desiredPosition, speed);
        my_camera_trans.position = smoothedPosition;

        if (current_stage >= end_stage)
        {
            out_timer += Time.deltaTime;

            cam_target = new Vector3 (cam_target.x += Random.Range(-0.5f,0.5f),cam_target.y += Random.Range(-0.5f,0.5f),cam_target.z);

            if (Random.Range(1,4) == 1)
            {
                flash_state = !flash_state;
                flash.SetActive(flash_state);
            }

            if (out_timer > 1f)
            {
                exit.switch_scenes();
            }
        }
    }

    void OnMouseDown()
    {
        if (current_stage < 50)
        {
            current_stage += 1;
        }
    }
}
