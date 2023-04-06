using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChoices : MonoBehaviour
{

    public float timer;
    public bool seen_all_VHS;
    public bool revealed;

    public GameObject choice_a;

    public GameObject choice_b_unlocked;
    public GameObject choice_b_locked;

    // Start is called before the first frame update
    void Start()
    {
        choice_a.SetActive(false);
        choice_b_locked.SetActive(false);
        choice_b_unlocked.SetActive(false);

        seen_all_VHS = true;
        if (!Mind.seen_apple_vhs) {seen_all_VHS = false;}
        if (!Mind.seen_flower_vhs) {seen_all_VHS = false;}
        if (!Mind.seen_mines_vhs) {seen_all_VHS = false;}
        if (!Mind.seen_orange_vhs) {seen_all_VHS = false;}
        if (!Mind.seen_hub_vhs) {seen_all_VHS = false;}
    }

    public void ChoiceMade(int towhere)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(towhere);
    }

    void Reveal()
    {
        if (!revealed)
        {
            revealed = true;
            choice_a.SetActive(true);
            if (seen_all_VHS)
            {
                choice_b_unlocked.SetActive(true);
            } else
            {
                choice_b_locked.SetActive(true);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5f)
        {
            Reveal();
        }
    }
}
