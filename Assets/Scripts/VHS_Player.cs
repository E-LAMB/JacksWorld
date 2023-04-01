using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS_Player : MonoBehaviour
{

    public GameObject my_camera;

    private float yaw, pitch;
    public float sensitivity;
    private Rigidbody rb;

    public bool should_be_in_control;

    public float time_active;

    bool false_standin;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {   
        if (!should_be_in_control)
        {
            time_active = 0f;
        }
        if (should_be_in_control)
        {

            // Debug.Log("Stamina: " + Mind.stamina + " MaxStamina: " + Mind.max_stamina);

            time_active += Time.deltaTime;

            //Camera Control
            if (false_standin)
            {
                Cursor.lockState = CursorLockMode.Confined;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
                pitch = Mathf.Clamp(pitch, -90, 90);
                yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
                my_camera.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);  
            }

        }
    }

    private void FixedUpdate()
    {
        if (should_be_in_control)
        {
            //Movement
            if (false_standin)
            {
                // nothing happens
            } else
            {
                Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 0f;
                Vector3 forward = new Vector3(-my_camera.transform.right.z, 0, my_camera.transform.right.x);
                Vector3 wishDirection = (forward * axis.x + my_camera.transform.right * axis.y + Vector3.up * rb.velocity.y);
                rb.velocity = wishDirection;
            }
        }
    }
}
