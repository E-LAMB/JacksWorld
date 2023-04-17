using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamSize : MonoBehaviour
{

    public Transform myself;

    public Vector3 new_size;

    public float size_decay;
    public float current_decay;

    public Vector3 big_size;

    public float divmod;

    // Start is called before the first frame update
    void Start()
    {
        big_size = myself.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_decay > size_decay)
        {
            new_size = big_size;
            current_decay = 0f;
        }

        current_decay += Time.deltaTime;
        new_size.x -= Time.deltaTime / divmod;
        new_size.z -= Time.deltaTime / divmod;
        new_size.z -= Time.deltaTime / divmod;

        myself.localScale = new_size;
    }
}
