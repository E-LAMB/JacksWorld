using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCoins : MonoBehaviour
{

    public bool good_ending;
    public GameObject good_coin;

    public bool bad_ending;
    public GameObject bad_coin;

    public bool safe_ending;
    public GameObject safe_coin;

    public bool stolen_ending;
    public GameObject stolen_coin;

    public bool got_one_ending;
    public GameObject black_1;
    public GameObject black_2;
    public GameObject black_3;
    public GameObject black_4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        good_ending = Mind.seen_good_ending;
        bad_ending = Mind.seen_bad_ending;
        safe_ending = Mind.seen_safe_ending;
        stolen_ending = Mind.seen_stolen_ending;

        got_one_ending = false;
        if (good_ending) {got_one_ending = true;}
        if (bad_ending) {got_one_ending = true;}
        if (safe_ending) {got_one_ending = true;}
        if (stolen_ending) {got_one_ending = true;}

        black_1.SetActive(got_one_ending);
        black_2.SetActive(got_one_ending);
        black_3.SetActive(got_one_ending);
        black_4.SetActive(got_one_ending);

        good_coin.SetActive(good_ending);
        bad_coin.SetActive(bad_ending);
        safe_coin.SetActive(safe_ending);
        stolen_coin.SetActive(stolen_ending);
    }
}
