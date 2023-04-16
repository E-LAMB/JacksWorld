using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipUploader : MonoBehaviour
{

    public AudioClip upload_jump;
    public AudioClip upload_dash;
    public AudioClip upload_death;
    public AudioClip upload_select;

    // Start is called before the first frame update
    void Start()
    {
        Mind.jump_clip = upload_jump;
        Mind.dash_clip = upload_dash;
        Mind.death_clip = upload_death;
        Mind.select_clip = upload_select;
    }
}
