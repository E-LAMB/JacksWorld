using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStart : MonoBehaviour
{

    public GameObject to_activate;
    public bool new_state = true;

    // Start is called before the first frame update
    void Start()
    {
        to_activate.SetActive(new_state);
    }

}
