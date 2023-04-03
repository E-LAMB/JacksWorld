using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBox : MonoBehaviour
{

    public Rigidbody2D my_body;
    public float my_force;

    public LayerMask conveyor_layer;
    public bool on_conveyor;
    public Transform checker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        on_conveyor = Physics2D.OverlapCircle(checker.position, 0.2f, conveyor_layer);

        if (on_conveyor)
        {
            my_body.velocity = new Vector2(my_force,my_body.velocity.y);
        }
    }
}
