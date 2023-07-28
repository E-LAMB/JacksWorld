using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public GameObject image_object;
    public RawImage my_image;
    public float time;

    public float modifier = 1f;

    void Start()
    {
        time = 1f;
        my_image.color = new Vector4(my_image.color.r, my_image.color.g, my_image.color.b, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * modifier;
        my_image.color = new Vector4(my_image.color.r, my_image.color.g, my_image.color.b, time);
        if (-0.1f > time)
        {
            image_object.SetActive(false);
        }
    }
}
