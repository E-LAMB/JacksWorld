using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool currently_dashing;
    public float max_dashing_cooldown;
    public float dashing_cooldown;
    public float dashing_max_heat;
    public float dashing_heat;
    public bool dashing_unlocked;
    public bool dashing_ready = true;

    public bool spare_jump_docked;
    public bool spare_jump_enabled;

    public Vector3 freeze_position;
    public bool got_frozen;

    public bool is_grounded;
    public bool at_checkpoint;
    public bool in_death;
    public GameObject ground_checker;
    public LayerMask ground_layer;
    public LayerMask checkpoint_layer;
    public LayerMask death_layer;

    public Vector3 respawn_position;

    public float movement_speed;
    public float dash_speed;
    public float jump_height;
    public float last_direction;

    public bool currently_moving;

    public Rigidbody2D my_rigidbody;

    public Animator my_animator;

    public Vector3 sprite_scale;
    public Transform sprite_trans;

    public Transform self;

    public void Jump(float height)
    {
        my_rigidbody.velocity = new Vector2(my_rigidbody.velocity.x,height);
        // my_rigidbody.AddForce(new Vector2(0.0f,height));
        my_animator.SetTrigger("Jumped");
    }

    public void SetCheckpoint()
    {
        respawn_position = self.position;
    }
    
    public void LoadCheckpoint()
    {
        self.position = respawn_position;
    }

    void Dash()
    {
        currently_dashing = true;
        my_animator.SetTrigger("Dashed");
    }

    void ConcludeDash()
    {
        dashing_heat = 0f;
        dashing_cooldown = max_dashing_cooldown;
        currently_dashing = false;
        dashing_ready = false;
    }

    void Start()
    {
        SetCheckpoint();
        Mind.player_in_control = true;
    }

    void Update()
    {
        if (Mind.player_in_control)
        {
            got_frozen = false;
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashing_ready && dashing_unlocked && last_direction != 0f)
            {
                Dash();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && currently_dashing)
            {
                ConcludeDash();
            }

            currently_moving = false;
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                last_direction = Input.GetAxisRaw("Horizontal");
                currently_moving = true;
            }

            if (!currently_dashing)
            {
                my_rigidbody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*movement_speed, my_rigidbody.velocity.y);
            }

            if (currently_dashing)
            {
                dashing_heat += Time.deltaTime;
                if (dashing_heat > dashing_max_heat)
                {
                    ConcludeDash();
                }
                my_rigidbody.velocity = new Vector2 (last_direction*dash_speed,0f);
            }

            if (dashing_cooldown > 0)
            {
                dashing_cooldown -= Time.deltaTime;
            } else
            {
                if (!dashing_ready)
                {
                    dashing_ready = true;
                }
            }
        } else
        {
            my_rigidbody.velocity = new Vector2 (0f,0f);
            currently_moving = false;
            currently_dashing = false;
            if (!got_frozen)
            {
                got_frozen = true;
                freeze_position = self.position;
            }
            self.position = freeze_position;
        }

        is_grounded = Physics2D.OverlapCircle(ground_checker.transform.position, 0.2f, ground_layer);
        at_checkpoint = Physics2D.OverlapCircle(ground_checker.transform.position, 0.2f, checkpoint_layer);
        in_death = Physics2D.OverlapCircle(ground_checker.transform.position, 0.2f, death_layer);

        if (is_grounded)
        {
            spare_jump_docked = true;
        }

        if (at_checkpoint)
        {
            SetCheckpoint();
        }

        if (in_death)
        {
            LoadCheckpoint();
        }

        if (is_grounded && !currently_dashing && Input.GetKeyDown(KeyCode.Space) && Mind.player_in_control)
        {
            Jump(jump_height);
        }

        if (!is_grounded && spare_jump_docked && spare_jump_enabled && !currently_dashing && Input.GetKeyDown(KeyCode.Space) && Mind.player_in_control)
        {
            Jump(jump_height);
            spare_jump_docked = false;
        }

        if (last_direction == 1)
        {
            sprite_scale.x = 1f;
        } else
        {
            sprite_scale.x = -1f;
        }
        
        sprite_trans.localScale = sprite_scale;

        my_animator.SetBool("IsGrounded",is_grounded);
        my_animator.SetBool("IsMoving",currently_moving);
        my_animator.SetBool("StillDashing",currently_dashing);

    }
}
