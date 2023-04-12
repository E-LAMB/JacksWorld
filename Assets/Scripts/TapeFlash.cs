using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeFlash : MonoBehaviour
{

    float timer;
    public float threshold;
    public GameObject gobject;
    public bool state;

    // Start is called before the first frame update
    void Awake()
    {
        state = true;
        gobject.SetActive(true);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > threshold)
        {
            state = !state;
            timer = 0f;
            gobject.SetActive(state);
        }
    }
}
