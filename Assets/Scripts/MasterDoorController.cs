using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDoorController : MonoBehaviour
{

    public bool doors_open;

    public MeshRenderer door_a;
    public MeshRenderer door_b;

    public Material trans_door;
    public Material opq_door;

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
            door_a.material = opq_door;
            door_b.material = opq_door;
        } else
        {
            door_a.material = trans_door;
            door_b.material = trans_door;
        }
    }
}
