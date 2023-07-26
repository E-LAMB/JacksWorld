using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JSText : MonoBehaviour
{
    public TextMeshPro the_text;
    public string[] text_selection;

    // Start is called before the first frame update
    void Start()
    {
        the_text.text = text_selection[Random.Range(0, text_selection.Length)];
    }
}
