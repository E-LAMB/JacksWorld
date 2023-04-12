using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject template;
    public GameObject recently_spawned;
    public SpawnedText recent_component;

    public Transform self;
    public Vector3 new_location;

    public float timer;

    public int quantity;
    public int quantity_done;

    public string to_assign;
    public string[] potential_assigned;

    public void Summon()
    {
        new_location.x = Random.Range(-2f,2f);
        new_location.y = Random.Range(-4f,1f);

        self.position = new_location;

        to_assign = potential_assigned[Random.Range(0,potential_assigned.Length)];

        recently_spawned = Instantiate(template, self.position, self.localRotation);
        recent_component = recently_spawned.GetComponent<SpawnedText>();
        recent_component.chosen_word = to_assign;

    }

    public void Summoner()
    {

        if (quantity_done > 0)
        {
            Summon();
        }

        quantity_done -= 1;

        if (quantity_done > 0)
        {
            Summoner();
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        quantity_done = quantity;
        Summoner();
    }
}
