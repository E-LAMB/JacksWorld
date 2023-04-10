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
    public float speed;

    public AudioSource my_source;

    public float distance;

    public bool waiting;
    public float wait_time;
    public float wait_threshold;

    public bool doors_are_open;

    public GameObject prompt;

    public GameObject jumpscare;

    Vector3 oob;

    // Start is called before the first frame update
    void Start()
    {
        oob.y = -20000f;
    }

    void BeginMovement()
    {
        new_target.x = new_target.x * -1f;
        my_source.Play();
        waiting = false;
        wait_time = 0f;
        wait_threshold = Random.Range(6f, 12f);
        speed += 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

        doors_are_open = my_doors.doors_open;

        is_outside = Physics.CheckSphere(gameObject.transform.position, 0.1f, death_layer);

        prompt.SetActive(Physics.CheckSphere(gameObject.transform.position, 7.5f, death_layer));

        self.position = Vector3.MoveTowards(self.position, new_target, Time.deltaTime * speed);

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

        if (is_outside && doors_are_open)
        {
            jumpscare.SetActive(true);
            self.position = oob;
        }
        
        if (wait_time > 2f)
        {
            BeginMovement();
        }

    }
}
