using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS2_Destination : MonoBehaviour
{
    
    public string accepting_who;
    public bool has_accepted;
    public SpriteRenderer my_sprite;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<VHS2_Letter>())
        {
            if (other.gameObject.GetComponent<VHS2_Letter>().in_space == false && other.gameObject.GetComponent<VHS2_Letter>().my_type == accepting_who && !has_accepted)
            {
                other.gameObject.GetComponent<VHS2_Letter>().FoundTarget(gameObject);
                Found();
            }
        }
    }

    public void Found()
    {
        has_accepted = true;
        my_sprite.enabled = false;
    }
    
}
