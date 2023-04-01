using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitle : MonoBehaviour
{

    public GameObject my_box;

    public TextMeshProUGUI name_text;
    public TextMeshProUGUI speaking_text;

    public void ShowDialouge(string what_to_say, string name_of_speaker)
    {
        speaking_text.text = what_to_say;
        name_text.text = name_of_speaker;
        my_box.SetActive(true);
    }

    public void ConcludeDialouge()
    {
        my_box.SetActive(false);
    }

}
