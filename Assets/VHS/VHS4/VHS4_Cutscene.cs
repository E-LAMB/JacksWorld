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

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
