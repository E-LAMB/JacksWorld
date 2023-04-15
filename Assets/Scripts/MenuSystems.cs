using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MenuSystems : MonoBehaviour
{

    public SaveSystem save_system;
    public TMP_Text the_text;
    public bool do_extra;

    public bool deac;

    public void AccessForm()
    {
        Application.OpenURL("https://forms.gle/KakJxdurpSNmEiK48");
    }

    public void Butt_New()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Butt_Target(int go_to)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(go_to);
    }

    public void Butt_Load()
    {

        save_system.SaveSystem_LOAD();

        // 0 = Hasn't played the game
        // 1 = Hub 1
        // 2 = Applefarm
        // 3 = Hub2
        // 4 = Flowerfield
        // 5 = Hub3
        // 6 = Mines
        // 7 = Hub4
        // 8 = Orange Outside
        // 9 = Orange Minigame
        // 10 = Out Of Bounds
        // 11 = Applefarm Revisit
        // 12 = Hub5
        // 13 = Home

        if (save_system.data_PROGRESS_current == 1) {UnityEngine.SceneManagement.SceneManager.LoadScene(2);}
        if (save_system.data_PROGRESS_current == 2) {UnityEngine.SceneManagement.SceneManager.LoadScene(3);}
        if (save_system.data_PROGRESS_current == 3) {UnityEngine.SceneManagement.SceneManager.LoadScene(4);}
        if (save_system.data_PROGRESS_current == 4) {UnityEngine.SceneManagement.SceneManager.LoadScene(5);}
        if (save_system.data_PROGRESS_current == 5) {UnityEngine.SceneManagement.SceneManager.LoadScene(6);}
        if (save_system.data_PROGRESS_current == 6) {UnityEngine.SceneManagement.SceneManager.LoadScene(7);}
        if (save_system.data_PROGRESS_current == 7) {UnityEngine.SceneManagement.SceneManager.LoadScene(8);}
        if (save_system.data_PROGRESS_current == 8) {UnityEngine.SceneManagement.SceneManager.LoadScene(9);}
        if (save_system.data_PROGRESS_current == 9) {UnityEngine.SceneManagement.SceneManager.LoadScene(10);}
        if (save_system.data_PROGRESS_current == 10) {UnityEngine.SceneManagement.SceneManager.LoadScene(11);}
        if (save_system.data_PROGRESS_current == 11) {UnityEngine.SceneManagement.SceneManager.LoadScene(12);}
        if (save_system.data_PROGRESS_current == 12) {UnityEngine.SceneManagement.SceneManager.LoadScene(13);}
        if (save_system.data_PROGRESS_current == 13) {UnityEngine.SceneManagement.SceneManager.LoadScene(14);}

    }

    public void Butt_SceneLevelSelect()
    {

        if (save_system.data_PROGRESS_current == 0) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        } else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(28);
        }

    }

    public void Butt_Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(30);
    }

    public void Butt_Quit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (deac)
        {
            Mind.return_to_vhs_menu = false;
        }

        if (do_extra)
        {
            save_system.SaveSystem_LOAD();
            if (save_system.data_PROGRESS_max == 0)
            {
                the_text.text = "NEW GAME";
            } else
            {
                the_text.text = "CONTINUE";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
