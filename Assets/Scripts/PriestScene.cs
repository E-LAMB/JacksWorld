using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestScene : MonoBehaviour
{

    public int required;
    public int needed;
    public int new_scene;
    public NPC_Script watching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        needed = watching.dia_state;
        if (required < needed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(new_scene);
        }
    }
}
