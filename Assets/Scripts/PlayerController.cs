using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image dash_icon;
    public Image jump_icon;
    public Image dash_icon_back;
    public Image jump_icon_back;

    public float dash_fraction;
    public float icon_dash_value;
    public float jump_fade = 0f;

    public AudioSource my_source;
    public AudioClip jump_clip;
    public AudioClip dash_clip;
    public AudioClip death_clip;

    public void Jump(float height)
    {
        my_rigidbody.velocity = new Vector2(my_rigidbody.velocity.x,height);
        // my_rigidbody.AddForce(new Vector2(0.0f,height));
        if (height > 0)
        {
            Playing(jump_clip);
            my_animator.SetTrigger("Jumped");
        }
    }

    public void SetCheckpoint()
    {
        respawn_position = self.position;
    }
    
    public void LoadCheckpoint()
    {
        Playing(death_clip);
        self.position = respawn_position;
    }

    void Dash()
    {
        currently_dashing = true;
        my_animator.SetTrigger("Dashed");
        icon_dash_value = max_dashing_cooldown;
        Playing(dash_clip);
    }

    void ConcludeDash()
    {
        dashing_heat = 0f;
        icon_dash_value = max_dashing_cooldown;
        dashing_cooldown = max_dashing_cooldown;
        currently_dashing = false;
        dashing_ready = false;
    }

    void Start()
    {
        SetCheckpoint();
        Mind.player_in_control = true;
        dash_icon = GameObject.Find("DashIcon").GetComponent<Image>();
        jump_icon = GameObject.Find("JumpIcon").GetComponent<Image>();
        dash_icon_back = GameObject.Find("DashIconBack").GetComponent<Image>();
        jump_icon_back = GameObject.Find("JumpIconBack").GetComponent<Image>();
        dashing_cooldown = 0f;
        jump_clip = Mind.jump_clip;
        dash_clip = Mind.dash_clip;
        death_clip = Mind.death_clip;
        my_source = gameObject.GetComponent<AudioSource>();
    }

    void Playing(AudioClip the_clip)
    {
        my_source.PlayOneShot(the_clip);
    }

    void Update()
    {
        my_source.volume = Mind.volume;
        if (dashing_unlocked && Mind.player_in_control)
        {
            dash_fraction = 1f - (dashing_cooldown / max_dashing_cooldown);
            dash_icon.fillAmount = dash_fraction;
            dash_icon.enabled = true;
            dash_icon_back.enabled = true;

        } else
        {
            dash_icon.enabled = false;
            dash_icon_back.enabled = false;
        }

        if (spare_jump_enabled && Mind.player_in_control)
        {
            if (spare_jump_docked)
            {
                jump_icon.color = new Vector4 (1f, 1f, 1f, 1f);
            } else
            {
                jump_icon.color = new Vector4 (1f, 1f, 1f, jump_fade);
            }
            jump_icon.enabled = true;
            jump_icon_back.enabled = true;
        } else
        {
            jump_icon.enabled = false;
            jump_icon_back.enabled = false;
        }

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

            if (dashing_cooldown > 0 && !currently_dashing)
            {
                icon_dash_value -= Time.deltaTime;
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
