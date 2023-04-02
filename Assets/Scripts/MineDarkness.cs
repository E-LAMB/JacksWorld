using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDarkness : MonoBehaviour
{

    public Transform boundary;

    public Transform player;

    public float difference;

    public float size;

    public Transform darkness;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        difference = boundary.position.x - player.position.x;
        difference = difference * -1f;

        difference = difference / speed;

        size = 3f - difference;

        if (size < 0.65f)
        {
            size = 0.65f;
        }

        if (0f > difference)
        {
            size = 200f;
        }

        darkness.localScale = new Vector3(size,size,size);
    }
}
