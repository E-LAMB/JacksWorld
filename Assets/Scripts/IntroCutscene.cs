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

        my_time += Time.deltaTime;

        if (0f < my_time && my_time < 4f)
        {
            objects[0].SetActive(true);
        }
        if (4f < my_time && my_time < 8f)
        {
            objects[1].SetActive(true);
        }
        if (8f < my_time && my_time < 12f)
        {
            objects[2].SetActive(true);
        }
        if (12f < my_time && my_time < 14f)
        {
            objects[3].SetActive(true);
        }
        if (14f < my_time && my_time < 16f)
        {
            objects[4].SetActive(true);
        }

        if (my_time > 16f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_warp);
        }
    }
}
