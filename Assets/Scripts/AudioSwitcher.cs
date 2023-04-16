using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{

    string the_tag = "MusicSource";
    GameObject the_object;
    DontDestroyOnLoadMusic the_script;

    public int new_audio;

    // Start is called before the first frame update
    void Start()
    {
        the_object = GameObject.FindWithTag(the_tag);
        the_script = the_object.GetComponent<DontDestroyOnLoadMusic>();
        the_script.ChangeTrack(new_audio);
        // Destroy(this.gameObject);
    }

}
