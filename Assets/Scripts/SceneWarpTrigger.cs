using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWarpTrigger : MonoBehaviour
{

    public int new_scene;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);
        }

    }

}
