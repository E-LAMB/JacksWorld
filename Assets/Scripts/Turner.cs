using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{

    public bool facing_wall = true;

    public Transform head; 

    float r;
    public float turning_angle;
    public float old_angle;

    public int turn_state;

    public CircleCollider2D death;
    public Transform death_trans;

    public bool currently_active;

    public float timer;
    public float wall_time;
    public float front_time;

    float turn_time;

    public Vector3 death_radius;
    public float detection_range;

    public float max_range;

    // Start is called before the first frame update
    void Start()
    {
        turn_time = wall_time;
    }

    void Turn()
    {
        if (facing_wall)
        {
            detection_range = 0.75f;
        }
        turning_angle += 180f;
        facing_wall = !facing_wall;
    }

    // Update is called once per frame
    void Update()
    {
        death_radius = new Vector3 (detection_range, detection_range, 1f);

        death_trans.localScale = death_radius;

        float new_angle = Mathf.SmoothDampAngle(head.eulerAngles.y, turning_angle, ref r, 0.1f);

        if (currently_active)
        {
            timer += Time.deltaTime;
        }

        if (timer > turn_time)
        {
            timer = 0f;
            Turn();
        }

        if (facing_wall)
        {
            turn_time = wall_time;
            detection_range -= Time.deltaTime * 8f;
            if (0f > detection_range)
            {
                detection_range = 0f;
                death.enabled = false;
            }
        } else 
        {
            turn_time = front_time;
            detection_range += Time.deltaTime * 2f;
            if (detection_range > max_range)
            {
                detection_range = max_range;
            }
            death.enabled = true;
        }

        head.localRotation = Quaternion.Euler(-90f,new_angle,0f);

    }
}
