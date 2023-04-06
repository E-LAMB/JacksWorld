using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOut : MonoBehaviour
{

    public bool moving_left;

    public float offset;

    public Vector3 target_position;

    public Transform coffin;

    public float speed;

    public float position_amount;

    public Rigidbody2D cam_body;
    public float cam_force;

    public bool autonomous;

    public GameObject to_hide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_left)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f || autonomous)
            {
                offset = 1f;
                moving_left = !moving_left;
                if (!autonomous)
                {
                    cam_body.velocity = new Vector2 (offset * cam_force, cam_body.velocity.y);
                    cam_force += 0.1f;
                }
            }
            
        }

        if (!moving_left)
        {
            if (Input.GetAxisRaw("Horizontal") == -1f || autonomous)
            {
                offset = -1f;
                moving_left = !moving_left;
                if (!autonomous)
                {
                    cam_body.velocity = new Vector2 (offset * cam_force, cam_body.velocity.y);
                    cam_force += 0.1f;
                }
            }
            
        }

        if (autonomous)
        {
            to_hide.SetActive(false);
            cam_force = 0f;
            offset = 0f;
            cam_body.velocity = new Vector2 (0f, cam_body.velocity.y);
        }

        if (cam_body.velocity.x > 15f)
        {
            autonomous = true;
        }

        target_position.x = offset * position_amount;

        Vector3 desiredPosition = target_position;
        Vector3 smoothedPosition = Vector3.Lerp(coffin.position, desiredPosition, speed);
        coffin.position = smoothedPosition;

    }
}
