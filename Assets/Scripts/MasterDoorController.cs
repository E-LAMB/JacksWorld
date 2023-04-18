using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDoorController : MonoBehaviour
{

    public bool doors_open;

    public MeshRenderer door_a;
    public MeshRenderer door_b;

    public Material trans_door;

    public float the_fade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doors_open = !Input.GetKey(KeyCode.Space);

        if (doors_open)
        {
            if (the_fade < 1f)
            {
                the_fade += Time.deltaTime / 10f;
            }
        } else
        {
            if (the_fade > 0.8f)
            {
                the_fade -= Time.deltaTime / 20f;
            }
        }

        trans_door.color = new Vector4 (1f, 1f, 1f, the_fade);

        door_a.material = trans_door;
        door_b.material = trans_door;
    }
}
