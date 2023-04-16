using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuParaGlitch : MonoBehaviour
{

    public bool has_gotten_an_ending;
    public bool has_gotten_para_ending;

    public bool show_glitch;

    public GameObject glitch_effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        has_gotten_an_ending = false;
        if (Mind.seen_good_ending) {has_gotten_an_ending = true;}
        if (Mind.seen_bad_ending) {has_gotten_an_ending = true;}
        if (Mind.seen_safe_ending) {has_gotten_an_ending = true;}
        if (Mind.seen_stolen_ending) {has_gotten_an_ending = true;}

        if (Mind.seen_stolen_ending) {has_gotten_para_ending = true;}

        if (has_gotten_an_ending && !has_gotten_para_ending)
        {
            show_glitch = true;
        } else
        {
            show_glitch = false;
        }

        glitch_effect.SetActive(show_glitch);

    }
}
