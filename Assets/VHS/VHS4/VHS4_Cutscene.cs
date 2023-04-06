using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS4_Cutscene : MonoBehaviour
{

    public int stage;

    public GameObject[] slides;

    public int scene_switch;

    public float timer;
    public float time_switch;
    public float time_to_exit;

    public GameObject flash;
    public bool flash_bool;

    public VHS_Exit exit;

    // Start is called before the first frame update
    void Start()
    {
        flash_bool = false;
        slides[0].SetActive(false);
        slides[1].SetActive(true);
        slides[2].SetActive(false);
        slides[3].SetActive(false);
        slides[4].SetActive(false);
        slides[5].SetActive(false);
        slides[6].SetActive(false);
        slides[7].SetActive(false);
        slides[8].SetActive(false);
        slides[9].SetActive(false);
        slides[10].SetActive(false);
        slides[11].SetActive(false);
        stage = 1;
        flash.SetActive(false);
    }

    void FlipPage()
    {
        slides[stage].SetActive(false);
        stage += 1;
        slides[stage].SetActive(true);
        if (stage == 10)
        {
            time_switch = 7f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time_switch)
        {
            timer = 0f;
            FlipPage();
        }

        if (stage > 10)
        {
            Debug.Log("Is Running");
            if (Random.Range(1,4) == 1)
            {
                flash_bool = !flash_bool;
                flash.SetActive(flash_bool);
            }
        }

        if (stage == 11)
        {
            time_to_exit += Time.deltaTime;
        }

        if (time_to_exit > 2f)
        {
            exit.switch_scenes();
        }
    }
}
