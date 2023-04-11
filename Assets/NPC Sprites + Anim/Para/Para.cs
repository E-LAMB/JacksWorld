using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Para : MonoBehaviour
{

    public Transform self;
    public Transform player;

    public GameObject go_self;

    public Rigidbody2D my_body;

    public bool in_sight;
    public bool is_awake;

    public LayerMask player_layer;

    public Vector3 player_direction;
    public Vector3 movement_direction;
    
    public float wakeup_range;

    Vector3 zero;

    public float speed;

    public float wait_time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!is_awake)        
        {

            if (Physics2D.OverlapCircle(transform.position, wakeup_range, player_layer))
            {
                is_awake = true;
            }

            in_sight = false;

        } else
        {
            if (!Mind.seen_good_ending)
            {
                go_self.SetActive(false);
            }
            wait_time += Time.deltaTime;
            if (wait_time > 120f) {in_sight = false;}

            if (!Physics2D.OverlapCircle(transform.position, wakeup_range, player_layer) && wait_time < 110f)
            {
                is_awake = false;
            }

            if (in_sight)
            {
                my_body.velocity = zero;
            } else
            {

                player_direction = player.position - self.position;
                player_direction.z = 0f;

                movement_direction = Vector3.Normalize(player_direction);
                movement_direction = movement_direction * speed;
                my_body.AddForce(movement_direction);
            }
        }

    }
}

