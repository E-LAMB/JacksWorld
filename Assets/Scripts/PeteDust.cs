using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeteDust : MonoBehaviour
{

    public LayerMask death_layer;
    public bool is_outside;

    public MasterDoorController my_doors;

    public Vector3 new_target;

    public Transform self;
    public float movement_speed;
    public float speed;

    public AudioSource my_source;

    public float distance;

    public bool waiting;
    public float wait_time;
    public float wait_threshold;

    public bool doors_are_open;

    public GameObject prompt;

    public GameObject jumpscare;

    public VHS_Clock the_clock;

    Vector3 oob;

    float max_thresh;

    public float outside_time;
    public bool is_outside_waiting;

    public GameObject my_smoke;
    public int passes;

    // Start is called before the first frame update
    void Start()
    {
        oob.y = -20000f;
        max_thresh = 6f;
        movement_speed = speed;
        passes = 20;
    }

    void BeginMovement()
    {
        new_target.x = new_target.x * -1f;
        my_source.Play();
        waiting = false;
        wait_time = 0f;
        wait_threshold = Random.Range(4f, max_thresh);
        speed += 0.25f;
        max_thresh += 0.5f;
        movement_speed = speed;
        is_outside_waiting = false;
        outside_time = -1f;
        if (the_clock.x_rotation > 100f && Random.Range(1,11) < passes)
        {
            outside_time = Random.Range(2f,7f);
            passes = 3;
        } else
        {
            passes += 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

        my_smoke.SetActive(is_outside_waiting);

        doors_are_open = my_doors.doors_open;

        is_outside = Physics.CheckSphere(gameObject.transform.position, 0.1f, death_layer);

        prompt.SetActive(Physics.CheckSphere(gameObject.transform.position, 7.5f, death_layer));

        self.position = Vector3.MoveTowards(self.position, new_target, Time.deltaTime * movement_speed);

        distance = Vector3.Distance(self.position, new_target);

        if (distance < 0.2f)
        {
            my_source.Stop();
            waiting = true;
        }

        if (waiting)
        {
            wait_time += Time.deltaTime;
        }

        if (self.position.x > -0.1f && 0.1f > self.position.x && !is_outside_waiting && outside_time > 0f)
        {
            movement_speed = 0f;
            outside_time -= Time.deltaTime;
            if (0.1f > outside_time)
            {
                is_outside_waiting = true;
                movement_speed = speed;
            }
        }

        if (is_outside && doors_are_open)
        {
            Mind.player_in_control = false;
            jumpscare.SetActive(true);
            self.position = oob;
        }
        
        if (wait_time > wait_threshold)
        {
            BeginMovement();
        }

    }
}
