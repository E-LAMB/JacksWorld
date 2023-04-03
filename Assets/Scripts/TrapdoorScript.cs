using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorScript : MonoBehaviour
{

    public bool currently_active;

    public GameObject td_open;
    public GameObject td_closed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currently_active)
        {
            td_closed.SetActive(false);
            td_open.SetActive(true);
        } else
        {
            td_closed.SetActive(true);
            td_open.SetActive(false);
        }
    }
}
