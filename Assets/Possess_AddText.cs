using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Possess_AddText : MonoBehaviour
{

    public int current_letter;
    public string the_string;
    public string[] all_letters;

    public TMPro.TextMeshProUGUI text_object;

    public RawImage jack;

    public GameObject scroll;

    void DooDee()
    {
        the_string += all_letters[current_letter];
        current_letter += 1;
        if (current_letter > all_letters.Length - 1)
        {
            current_letter = 0;
        }
        text_object.text = the_string;
    }

    // Update is called once per frame
    void Update()
    {
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 
        DooDee(); DooDee(); DooDee(); DooDee(); DooDee(); 

        scroll.transform.position = scroll.transform.position + (Vector3.up * 30f);

        scroll.transform.position = new Vector3 (Random.Range(900f, 1020f), scroll.transform.position.y, scroll.transform.position.z);

        jack.color = new Vector4 (Random.Range(0.9f,1f), Random.Range(0.9f,1f), Random.Range(0.9f,1f), 1f);
    }
}
