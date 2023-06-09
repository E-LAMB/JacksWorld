using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadMusic : MonoBehaviour
{

    public int current_track;
    public AudioSource my_source;
    public AudioSource singluar;

    public AudioClip[] tracks;

    public void ChangeTrack(int new_track)
    {
        if (new_track != current_track)
        {
            current_track = new_track;
            // 0 = None
            // 1 = Apples - Mines
            // 2 = Mines - OOB
            // 3 = OOB - Applefarm RV

            if (new_track > 0) {my_source.clip = tracks[new_track];}
 
            my_source.Play();
                     
            if (new_track == 0) {my_source.Stop();}

        }
    }

    void Update()
    {
        my_source.volume = Mind.volume;
        /*
        if (Mind.played_select)
        {
            Mind.played_select = false;
            singluar.PlayOneShot(Mind.select_clip);
        }
        */
    }

    void Awake()
    {
        
        GameObject[] other_sources = GameObject.FindGameObjectsWithTag("MusicSource");
        if (other_sources.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
