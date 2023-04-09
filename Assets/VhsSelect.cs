using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VhsSelect : MonoBehaviour
{

    public TextMeshPro my_title;

    public int selected_location;

    public UnityEngine.UI.Slider my_slider;

    public SaveSystem the_system;

    public string[] titles;
    public GameObject[] icons;

    public bool show_lock;

    public bool[] seen_the_tape;

    public GameObject tapewarning;

    public void selecting_level()
    {
        if (selected_location == 0) {UnityEngine.SceneManagement.SceneManager.LoadScene(2);}
        if (selected_location == 1) {UnityEngine.SceneManagement.SceneManager.LoadScene(3);}
        if (selected_location == 2) {UnityEngine.SceneManagement.SceneManager.LoadScene(4);}
        if (selected_location == 3) {UnityEngine.SceneManagement.SceneManager.LoadScene(5);}
        if (selected_location == 4) {UnityEngine.SceneManagement.SceneManager.LoadScene(6);}
    }

    public void go_to_level(int to_go)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(to_go);
    }

    void show_icon()
    {

        icons[0].SetActive(false);
        icons[1].SetActive(false);
        icons[2].SetActive(false);
        icons[3].SetActive(false);
        icons[4].SetActive(false);

        icons[selected_location].SetActive(true);
        my_title.text = titles[selected_location];

        if (seen_the_tape[selected_location])
        {
            show_lock = false;
        } else
        {
            show_lock = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        seen_the_tape[0] = Mind.seen_apple_vhs;
        seen_the_tape[1] = Mind.seen_flower_vhs;
        seen_the_tape[2] = Mind.seen_mines_vhs;
        seen_the_tape[3] = Mind.seen_orange_vhs;
        seen_the_tape[4] = Mind.seen_hub_vhs;

        selected_location = Mathf.RoundToInt(my_slider.value);
        show_icon();
    }

    // Update is called once per frame
    void Update()
    {
        
        tapewarning.SetActive(show_lock);

        if (my_slider.value != selected_location)
        {
            selected_location = Mathf.RoundToInt(my_slider.value);
            show_icon();
        }

        selected_location = Mathf.RoundToInt(my_slider.value);

    }
}
