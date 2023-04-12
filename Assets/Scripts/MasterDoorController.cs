using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDoorController : MonoBehaviour
{

    public bool doors_open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doors_open = !Input.GetKey(KeyCode.Space);
    }
}
