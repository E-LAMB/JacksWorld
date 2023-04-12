using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light my_light;

    public float max_light;
    public float min_light;

    public float chosen_light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chosen_light = Random.Range(min_light,max_light);
        my_light.range = chosen_light;
    }
}
