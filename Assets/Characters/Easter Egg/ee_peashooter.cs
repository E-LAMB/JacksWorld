using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ee_peashooter : MonoBehaviour
{

    public int appearance_chance;
    public Animator my_anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            my_anim.SetTrigger("Activate");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(1, appearance_chance) != 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
