using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{

    public OrangeMinigame my_minigame_manager;

    public GameObject sign_1;
    public GameObject sign_2;
    public GameObject sign_3;
    public GameObject sign_4;
    public GameObject sign_5;
    public GameObject sign_6;
    public GameObject sign_7;
    public GameObject sign_8;
    public GameObject sign_9;
    public GameObject sign_10;
    public GameObject sign_done;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        sign_1.SetActive(false);
        sign_2.SetActive(false);
        sign_3.SetActive(false);
        sign_4.SetActive(false);
        sign_5.SetActive(false);
        sign_6.SetActive(false);
        sign_7.SetActive(false);
        sign_8.SetActive(false);
        sign_9.SetActive(false);
        sign_10.SetActive(false);
        sign_done.SetActive(false);

        if (my_minigame_manager.minigame_active)
        {

            if (my_minigame_manager.remaining_fruits == 10)
            {
                sign_10.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 9)
            {
                sign_9.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 8)
            {
                sign_8.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 7)
            {
                sign_7.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 6)
            {
                sign_6.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 5)
            {
                sign_5.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 4)
            {
                sign_4.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 3)
            {
                sign_3.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 2)
            {
                sign_2.SetActive(true);
            }
            if (my_minigame_manager.remaining_fruits == 1)
            {
                sign_1.SetActive(true);
            }

        } else
        {
            sign_done.SetActive(true);
        }
    }
}
