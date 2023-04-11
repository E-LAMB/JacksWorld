using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTV : MonoBehaviour
{

    public DormisInteraction dormis_npc_script;
    public bool has_talked_to;
    public GameObject tv_loader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dormis_npc_script.dia_state > 7)
        {
            has_talked_to = true;
        }
        if (has_talked_to)
        {
            tv_loader.SetActive(true);
        }
    }
}
