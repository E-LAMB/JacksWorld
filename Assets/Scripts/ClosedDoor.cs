using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{

    public MasterDoorController my_controller;
    public bool should_be_open;

    public Transform open;
    public Transform closed;

    public Vector3 target;

    public Transform self;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        should_be_open = my_controller.doors_open;

        if (should_be_open)
        {
            target = open.position;
        } else
        {
            target = closed.position;
        }

        Vector3 desiredPosition = target;
        Vector3 smoothedPosition = Vector3.Lerp(self.position, desiredPosition, speed);
        self.position = smoothedPosition;
    }
}
