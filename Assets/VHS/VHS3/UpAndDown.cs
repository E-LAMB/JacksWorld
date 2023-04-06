using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{

    public AnimationCurve height;
    public AnimationCurve looking;

    public Transform scamera;

    public Vector3 cam_trans;

    public float timer;
    public float timer2;

    // Start is called before the first frame update
    void Start()
    {
        cam_trans = scamera.position;
    }

    // Update is called once per frame
    void Update()
    {
        cam_trans.y = height.Evaluate(timer);

        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            timer -= 5f;
        }
        timer2 += Time.deltaTime / 2f;
        if (timer2 >= 5f)
        {
            timer2 -= 5f;
        }

        scamera.localRotation = Quaternion.Euler(looking.Evaluate(timer2),0f,0f);

        scamera.position = cam_trans;
        
    }
}
