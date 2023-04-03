using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanEnemy : MonoBehaviour
{

    public Transform self;
    public Transform player;

    public Rigidbody2D my_body;

    public bool in_sight;
    public bool is_awake;

    public Animator my_animator;
    public bool anim_moving;

    public LayerMask player_layer;
    public LayerMask sight_layer;

    public Vector3 player_direction;
    public Vector3 movement_direction;
    
    public float wakeup_range;

    Vector3 zero;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        self.localRotation = Quaternion.Euler(0f,0f,Random.Range(0f,360f));
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

            anim_moving = false;

        } else
        {
            in_sight = Physics2D.OverlapCircle(transform.position, 1f, sight_layer);

            if (in_sight)
            {
                anim_moving = false;
                my_body.velocity = zero;
            } else
            {
                anim_moving = true;

                player_direction = player.position - self.position;
                player_direction.z = 0f;

                movement_direction = Vector3.Normalize(player_direction);
                movement_direction = movement_direction * speed;
                my_body.AddForce(movement_direction);
            }
        }

        my_animator.SetBool("Moving", anim_moving);

    }
}
