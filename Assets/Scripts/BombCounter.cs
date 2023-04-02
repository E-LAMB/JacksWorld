using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCounter : MonoBehaviour
{

    public int interactions;

    public GameObject old_amara;
    public GameObject new_amara;

    public GameObject exit_door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
        if (interactions == 4)
        {
            old_amara.SetActive(false);
            new_amara.SetActive(true);
            exit_door.SetActive(true);
            GetComponent<BombCounter>().enabled = false;
        }
    }
}
