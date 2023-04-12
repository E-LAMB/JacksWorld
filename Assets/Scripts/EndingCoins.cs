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

        good_coin.SetActive(good_ending);
        bad_coin.SetActive(bad_ending);
        safe_coin.SetActive(safe_ending);
        stolen_coin.SetActive(stolen_ending);
    }
}
