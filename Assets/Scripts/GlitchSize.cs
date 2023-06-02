using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchSize : MonoBehaviour
{

    public Transform self;
    public float smallest;
    public float largest;
    public float v;

    void Start()
    {
        self = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Random.Range(smallest, largest);
        self.localScale = new Vector3 (v,v,v);
    }
}
