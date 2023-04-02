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

    public GameObject death;

    public bool currently_active;

    public float timer;
    public float turn_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Turn()
    {
        turning_angle += 180f;
        facing_wall = !facing_wall;
    }

    // Update is called once per frame
    void Update()
    {

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
            death.SetActive(false);
        } else 
        {
            death.SetActive(true);
        }

        head.localRotation = Quaternion.Euler(-90f,new_angle,0f);

    }
}
