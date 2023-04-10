using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton_Death : MonoBehaviour
{

    public bool box_on_me;
    public GameObject box_checker;
    public LayerMask box_layer;

    public GameObject death_field;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        box_on_me = Physics2D.OverlapCircle(box_checker.transform.position, 0.2f, box_layer);

        death_field.SetActive(!box_on_me);
    }
}
