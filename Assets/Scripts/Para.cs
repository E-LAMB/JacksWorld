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
            if (Mind.para_progress != 3)
            {
                go_self.SetActive(false);
            }

            wait_time += Time.deltaTime;

            if (wait_time > 25f) 
            {
                in_sight = false;
            } else
            {
                in_sight = true;
            }

            if (!Physics2D.OverlapCircle(transform.position, wakeup_range, player_layer) && wait_time < 24f)
            {
                is_awake = false;
            }

            if (wait_time > 25f)
            {
                Mind.player_in_control = false;
            }

            if (in_sight)
            {
                my_body.velocity = zero;
            } else
            {

                speed += Time.deltaTime / 1.4f;

                player_direction = player.position - self.position;
                player_direction.z = 0f;

                Vector3 target = player.position;
                target.z = self.position.z;

                self.position = Vector3.MoveTowards(self.position, target, Time.deltaTime * speed);
            }
        }

    }
}

