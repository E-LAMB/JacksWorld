using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS2_Letter : MonoBehaviour
{

    public Transform self;
    public Transform target;

    public GameObject self_ob;
    public GameObject target_ob;

    public SpriteRenderer target_renderer;
    public SpriteRenderer self_renderer;

    public float distance;
    public float snap_distance;

    public Vector3 moving_to;
    public Vector3 drag_offset;
    public Rigidbody2D my_body;

    public VHS2_Counter my_counter;

    public Vector4 new_color;

    public bool in_space;

    public float left_bound;
    public float right_bound;

    public float up_bound;
    public float down_bound;

    // Start is called before the first frame update
    void Start()
    {

        self.position = new Vector3 (Random.Range(left_bound,right_bound),Random.Range(up_bound,down_bound),0f);

        target_renderer = target_ob.GetComponent<SpriteRenderer>();
        self_renderer = self_ob.GetComponent<SpriteRenderer>();
        /*
        self_ob = gameObject;
        self = self_ob.GetComponent<Transform>();
        target = target_ob.GetComponent<Transform>();
        my_body = self_ob.GetComponent<Rigidbody2D>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        self_renderer.color = new_color;
        distance = Vector3.Distance(self.position, target.position);
        target_renderer.enabled = !in_space;
        if (snap_distance > distance && !in_space)
        {
            in_space = true;
            my_counter.letters_placed += 1;
        }
        if (in_space) 
        {
            self.position = target.position;

            if (my_counter.puzzle_completed)
            {
                if (new_color.y >= 0f)
                {
                    new_color.y -= Time.deltaTime / 4f;
                }
                if (new_color.z >= 0f)
                {
                    new_color.z -= Time.deltaTime / 4f;
                }
            }

            /*
            if (new_color.y < 1f)
            {
                new_color.y += Time.deltaTime;
            }
            if (new_color.z < 1f)
            {
                new_color.z += Time.deltaTime;
            }
            */
        }
    }

    void OnMouseDrag()
    {
        if (!in_space)
        {
            WhileGrabbed();
        }
    }

    void OnMouseDown()
    {
        drag_offset = self.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        drag_offset.z = self.position.z;
    }

    void WhileGrabbed()
    {

        my_body.velocity = Vector2.zero;
        moving_to = Camera.main.ScreenToWorldPoint(Input.mousePosition) + drag_offset;
        moving_to.z = self.position.z;
        self.position = moving_to;
        
    }

}
