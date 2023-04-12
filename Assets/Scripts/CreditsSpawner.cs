using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsSpawner : MonoBehaviour
{

    public GameObject template;
    public GameObject recently_spawned;
    public TMP_Text recent_component;

    public Transform self;
    public Vector3 new_location;

    public float timer;
    public float needed_time = 2f;

    public string to_assign;
    public string[] potential_assigned;

    public void Summon()
    {
        new_location.x = Random.Range(-1f,1f);
        new_location.y = Random.Range(10f,10f);

        self.position = new_location;

        to_assign = potential_assigned[Random.Range(0,potential_assigned.Length)];

        recently_spawned = Instantiate(template, self.position, self.localRotation);
        recent_component = recently_spawned.GetComponent<TMP_Text>();
        recent_component.text = to_assign;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > needed_time)
        {
            needed_time -= 0.1f;
            if (needed_time < 0.3f)
            {
                needed_time = 0.3f;
            }
            timer = 0f;
            Summon();
        }
    }
}
