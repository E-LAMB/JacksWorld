using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float speed = 0.5f;
    public float my_height;
    public bool manual_height;

    public Vector3 offset;
    
    void Start()
    {
        if (!manual_height)
        {
            my_height = transform.position.y;
        }
    }

    void FixedUpdate()
    {

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        if (my_height > smoothedPosition.y)
        {
            smoothedPosition.y = my_height;
        }
        transform.position = smoothedPosition;

    }

}
