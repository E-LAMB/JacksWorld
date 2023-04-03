using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanEnemy : MonoBehaviour
{

    public Transform self;

    public Rigidbody2D my_body;

    public bool in_sight;
    public bool is_awake;

    public Animator my_animator;
    public bool anim_moving;

    public LayerMask player_layer;
    public LayerMask sight_layer;

    public Vector3 player_direction;
    
    public float wakeup_range;

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

            anim_moving = false;

        } else
        {
            in_sight = Physics2D.OverlapCircle(transform.position, 1f, sight_layer)

            if (in_sight)
            {
                anim_moving = false;

            } else
            {
                anim_moving = true;

                
            }
        }

        my_animator.SetBool("Moving", anim_moving);

    }
}
