using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGlitchIcon : MonoBehaviour
{

    public int max_word_count;
    public int word_count;

    public string built_string;

    public string[] word_collection;

    public TextMeshPro the_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartBuilding()
    {
        word_count = max_word_count;
        built_string = "";
        KeepBuilding();
    }

    void KeepBuilding()
    {
        if (word_count > 0)
        {
            word_count -= 1;
            AddWord();
            KeepBuilding();
        }
    }

    void AddWord()
    {
        int chosen = Random.Range(0, word_collection.Length);
        built_string += word_collection[chosen];
        built_string += " ";
    }

    // Update is called once per frame
    void Update()
    {
        StartBuilding();
        the_text.text = built_string;
    }
}
