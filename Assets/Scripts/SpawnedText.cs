using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnedText : MonoBehaviour
{

    public string chosen_word;
    public TextMeshPro my_text;
    public float frames_to_show;
    public float frames_shown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my_text.text = chosen_word;
        frames_shown += Time.deltaTime;
        if (frames_shown > frames_to_show)
        {
            Destroy(gameObject);
        }

    }
}
