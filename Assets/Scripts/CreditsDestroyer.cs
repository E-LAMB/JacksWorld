using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsDestroyer : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Debug.Log(other.tag);

        if (other.tag == "SkullBox")
        {
            Debug.Log("DESTROY");
            Destroy(other.gameObject);
        }
    }

}
