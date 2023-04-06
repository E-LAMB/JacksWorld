using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS_Exit : MonoBehaviour
{

    public int after_hub;

    public void switch_scenes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(after_hub);
    }

}
