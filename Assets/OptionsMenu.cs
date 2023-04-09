using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    // Options:
    // - Reset Game Data (Are You Sure) (You're 100% serious about this?) (Click to RESET GAME DATA)
    // - Volume?
    // - Brightness?

    public SaveSystem the_sys;

    public GameObject RGD_button_1;
    public GameObject RGD_button_2;

    public void AreYouSure()
    {
        RGD_button_1.SetActive(false);
        RGD_button_2.SetActive(true);
    }

    public void ResetGameData()
    {
        Mind.has_done_startup = false;
        the_sys.SaveSystem_RESET();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}