using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeMinigame : MonoBehaviour
{

    public int remaining_fruits;

    public bool minigame_active;
    public bool done_dia;
    public GameObject ora;
    public GameObject death_barrier;

    public float ora_title;

    public void OrangePassed()
    {
        remaining_fruits -= 1;
    }

    public void SkullPassed()
    {
        remaining_fruits = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        minigame_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (0 >= remaining_fruits)
        {
            if (!done_dia)
            {
                done_dia = true;
                ora.SetActive(true);
            }
            if (done_dia)
            {
                ora_title += Time.deltaTime;
            }
            if (ora_title > 3f)
            {
                ora.SetActive(false);
            }
            minigame_active = false;
            death_barrier.SetActive(false);
        }

        
    }
}
