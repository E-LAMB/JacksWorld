using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{

    public TextMeshPro my_title;
    public int maximum_location;

    public int selected_location;

    public UnityEngine.UI.Slider my_slider;

    public SaveSystem the_system;

    public string[] titles;
    public GameObject[] icons;

    public void selecting_level()
    {
        if (selected_location == 1) {UnityEngine.SceneManagement.SceneManager.LoadScene(2);}
        if (selected_location == 2) {UnityEngine.SceneManagement.SceneManager.LoadScene(3);}
        if (selected_location == 3) {UnityEngine.SceneManagement.SceneManager.LoadScene(4);}
        if (selected_location == 4) {UnityEngine.SceneManagement.SceneManager.LoadScene(5);}
        if (selected_location == 5) {UnityEngine.SceneManagement.SceneManager.LoadScene(6);}
        if (selected_location == 6) {UnityEngine.SceneManagement.SceneManager.LoadScene(7);}
        if (selected_location == 7) {UnityEngine.SceneManagement.SceneManager.LoadScene(8);}
        if (selected_location == 8) {UnityEngine.SceneManagement.SceneManager.LoadScene(9);}
        if (selected_location == 9) {UnityEngine.SceneManagement.SceneManager.LoadScene(10);}
        if (selected_location == 10) {UnityEngine.SceneManagement.SceneManager.LoadScene(11);}
        if (selected_location == 11) {UnityEngine.SceneManagement.SceneManager.LoadScene(12);}
        if (selected_location == 12) {UnityEngine.SceneManagement.SceneManager.LoadScene(13);}
        if (selected_location == 13) {UnityEngine.SceneManagement.SceneManager.LoadScene(14);}
    }

    void show_icon()
    {

        icons[0].SetActive(false);
        icons[1].SetActive(false);
        icons[2].SetActive(false);
        icons[3].SetActive(false);
        icons[4].SetActive(false);
        icons[5].SetActive(false);
        icons[6].SetActive(false);
        icons[7].SetActive(false);
        icons[8].SetActive(false);
        icons[9].SetActive(false);
        icons[10].SetActive(false);
        icons[11].SetActive(false);
        icons[12].SetActive(false);
        icons[13].SetActive(false);

        icons[selected_location].SetActive(true);
        my_title.text = titles[selected_location];

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        maximum_location = the_system.data_PROGRESS_max;
        if (maximum_location == 0)
        {
            my_slider.minValue = 0;
        } else
        {
            my_slider.minValue = 1;
        }
        my_slider.maxValue = maximum_location;
        //extracted_value = my_slider.value;
        //rounded_value = Mathf.Round(extracted_value);
        if (my_slider.value != selected_location)
        {
            selected_location = Mathf.RoundToInt(my_slider.value);
            show_icon();
        }
        selected_location = Mathf.RoundToInt(my_slider.value);

    }
}
