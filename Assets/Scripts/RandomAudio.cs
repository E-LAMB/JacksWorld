using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{

    public AudioSource my_source;
    public AudioClip[] all_clips;
    public AudioClip chosen_clip;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(4f,28f);
    }

    void RandomClip()
    {
        chosen_clip = all_clips[Random.Range(0, all_clips.Length)];
        
        my_source.pitch = Random.Range(-3f, 3f);
        my_source.volume = Random.Range(0.8f, 1.1f);

        my_source.PlayOneShot(chosen_clip);
        //my_source.Play();

        timer = Random.Range(6f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (0f > timer)
        {
            RandomClip();
        }
    }
}
