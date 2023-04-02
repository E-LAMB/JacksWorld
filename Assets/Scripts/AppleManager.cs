using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{

    public int apples_collected;

    public GameObject old_amara;
    public GameObject new_amara;

    // public GameObject exit_door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (apples_collected == 3)
        {
            old_amara.SetActive(false);
            new_amara.SetActive(true);
            // exit_door.SetActive(true);
            GetComponent<AppleManager>().enabled = false;
        }
    }
}
