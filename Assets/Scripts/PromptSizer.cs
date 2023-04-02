using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptSizer : MonoBehaviour
{

    public Vector3 ideal_size;
    public Transform self;
    public float size_comparison_x;
    public float size_comparison_y;
    public float size_comparison_z;

    // Start is called before the first frame update
    void Start()
    {
        size_comparison_x = self.localScale.x / self.lossyScale.x;
        size_comparison_y = self.localScale.y / self.lossyScale.y;
        size_comparison_z = self.localScale.z / self.lossyScale.z;

        ideal_size = new Vector3(Mind.prompt_size * size_comparison_x,Mind.prompt_size * size_comparison_y,Mind.prompt_size * size_comparison_z);

        self.localScale = ideal_size;
    }

}
