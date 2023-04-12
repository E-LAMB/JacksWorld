using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DyingPlayerController : MonoBehaviour
{

    public Rigidbody2D my_body;
    public Transform my_trans;
    public float speed;
    public float size;

    public Animator my_anim;

    public Vector3 scale;

    public float fake_input;

    public bool is_at_end;
    public LayerMask end_layer;

    public float trans_text;
    public TextMeshPro text_comp;

    public float exit_time;
    public int new_scene;

    public bool player_started_walking;

    public float time_here;

    public Camera my_camera;
    public AnimationCurve my_cam_curve;

    public SpriteRenderer blocker;
    public float clear_time;

    public CameraController cam_cont;

    public SpriteRenderer self;
    public float self_trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        is_at_end = Physics2D.OverlapCircle(my_trans.position, 0.5f, end_layer);

        if (is_at_end || exit_time > 1f)
        {

            if (trans_text < 1f)
            {
                trans_text += Time.deltaTime / 4f;
            }

            text_comp.color = new Vector4 (0f,0f,0f, trans_text);

            exit_time += Time.deltaTime;

            if (exit_time > 6f)
            {
                cam_cont.enabled = false;
                fake_input += Time.deltaTime;
            } else
            {
                fake_input -= Time.deltaTime;
            }

        }

        if (exit_time > 6f)
        {
            self_trans -= Time.deltaTime / 3f;
        }
        self.color = new Vector4(0f, 0f, 0f, self_trans);

        time_here += Time.deltaTime;

        my_camera.orthographicSize = my_cam_curve.Evaluate(time_here);

        if (clear_time > 0f)
        {
            clear_time -= Time.deltaTime / 3f;
            blocker.color = new Vector4 (0f, 0f, 0f, clear_time);
        }

        if (!player_started_walking && time_here > 5f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                fake_input = 1.5f;
                player_started_walking = true;
            }
        }

        if (exit_time > 12f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);
        }

        if (fake_input < 0f)
        {
            fake_input = 0f;
        }
        if (fake_input > 1.5f)
        {
            fake_input = 1.5f;
        }

        my_body.velocity = new Vector2(speed * fake_input, my_body.velocity.y);

        if (fake_input != 0)
        {
            my_anim.SetBool("IsMoving", true);
            scale.x = size;
        } else
        {
            my_anim.SetBool("IsMoving", false);
        }

        my_trans.localScale = scale;
    }
}
