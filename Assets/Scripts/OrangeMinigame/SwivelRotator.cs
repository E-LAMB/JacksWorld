using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwivelRotator : MonoBehaviour
{

    public float ideal_angle = 15f;

    float r;

    public Transform self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float new_angle = Mathf.SmoothDampAngle(self.eulerAngles.z, ideal_angle, ref r, 0.1f);
        self.localRotation = Quaternion.Euler(0f,0f,new_angle);

    }
}
