using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOnceEnding : MonoBehaviour
{

    public SaveSystem sys;
    public bool has_gotten_an_ending;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f && !has_gotten_an_ending)
        {
            sys.SaveSystem_LOAD();
            has_gotten_an_ending = false;
            if (Mind.seen_good_ending) {has_gotten_an_ending = true;}
            if (Mind.seen_bad_ending) {has_gotten_an_ending = true;}
            if (Mind.seen_safe_ending) {has_gotten_an_ending = true;}
            if (Mind.seen_stolen_ending) {has_gotten_an_ending = true;}
            if (has_gotten_an_ending == false) {Destroy(gameObject);}
        }
    }
}
