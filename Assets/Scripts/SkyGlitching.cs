using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGlitching : MonoBehaviour
{

    public float r_default;
    public float g_default;
    public float b_default;

    public float twitch_range;

    public Vector4 my_color;
    public Camera my_camera;

    public AnimationCurve darkness;
    public float dark_time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        my_color = new Vector4(r_default + Random.Range(twitch_range * -1f, twitch_range), g_default + Random.Range(twitch_range * -1f, twitch_range), b_default + Random.Range(twitch_range * -1f, twitch_range), 1f);
        
        dark_time += Time.deltaTime;
        my_color = new Vector4 (my_color.x - darkness.Evaluate(dark_time), my_color.y - darkness.Evaluate(dark_time), my_color.z - darkness.Evaluate(dark_time), 1f);
        
        my_camera.backgroundColor = my_color;

    }
}
