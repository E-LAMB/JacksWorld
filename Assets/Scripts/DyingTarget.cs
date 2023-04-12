using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingTarget : MonoBehaviour
{

    public Transform self;
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        self.position = offset + player.position;
    }
}
