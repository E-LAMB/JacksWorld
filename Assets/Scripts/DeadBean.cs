using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBean : MonoBehaviour
{
    
    public Transform self;

    // Start is called before the first frame update
    void Start()
    {
        self.localRotation = Quaternion.Euler(0f,0f,Random.Range(0f,360f));
    }

}
