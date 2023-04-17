using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareCam : MonoBehaviour
{

    public float timer;

    public Transform self;

    public float new_angle;
    public AnimationCurve turning;

    public GameObject screen_text;

    public int new_scene; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        new_angle = turning.Evaluate(timer);
        self.localRotation = Quaternion.Euler(new_angle,0f,0f);

        if (timer > 8f)
        {
            screen_text.SetActive(true);
        }

        if (timer > 13f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);
        }

    }
}
