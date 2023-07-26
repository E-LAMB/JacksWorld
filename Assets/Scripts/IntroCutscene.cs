using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{

    public GameObject[] objects;
    public float my_time;
    public int scene_to_warp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objects[0].SetActive(false);
        objects[1].SetActive(false);
        objects[2].SetActive(false);
        objects[3].SetActive(false);
        objects[4].SetActive(false);
        objects[5].SetActive(false);

        my_time += Time.deltaTime;

        if (0f < my_time && my_time < 3f)
        {
            objects[0].SetActive(true);
        }
        if (3f < my_time && my_time < 6f)
        {
            objects[1].SetActive(true);
        }
        if (6f < my_time && my_time < 9f)
        {
            objects[2].SetActive(true);
        }
        if (9f < my_time && my_time < 12f)
        {
            objects[3].SetActive(true);
        }
        if (12f < my_time && my_time < 15f)
        {
            objects[4].SetActive(true);
        }
        if (15f < my_time && my_time < 17f)
        {
            objects[5].SetActive(true);
        }

        if (my_time > 17.5f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_warp);
        }
    }
}
