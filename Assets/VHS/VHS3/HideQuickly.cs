using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideQuickly : MonoBehaviour
{

    float timer;
    public float needed_time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > needed_time)
        {
            Destroy(gameObject);
        }   
    }
}
