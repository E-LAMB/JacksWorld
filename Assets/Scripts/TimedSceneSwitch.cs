using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSceneSwitch : MonoBehaviour
{
    public float timer;
    public float threshold;
    public int new_scene;

    // Update is called once per frame
    void Update()
    {
        if (timer > threshold)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);
        }
        timer += Time.deltaTime;
    }
}
