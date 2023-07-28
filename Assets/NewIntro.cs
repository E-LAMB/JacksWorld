using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewIntro : MonoBehaviour
{

    public float cutscene_time;
    public bool moving;

    public Animator my_animator;
    public Transform sprite;

    public Transform self;

    public Subtitle sub_sys;

    public RawImage my_image;
    public float fade_time;

    public int state;

    [TextArea(5,20)]
    public string txt_1 = "";

    [TextArea(5,20)]
    public string txt_2 = "";

    [TextArea(5,20)]
    public string txt_3 = "";

    [TextArea(5,20)]
    public string txt_4 = "";

    // Start is called before the first frame update
    void Start()
    {
        state = -1;
        fade_time = -0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        cutscene_time += Time.deltaTime;

        if (state == -1)
        {
            sprite.localScale = new Vector3 (1f, 1f, 1f);
            my_animator.SetBool("IsMoving",true);
            moving = true;
            state = 0;
        }

        if (moving)
        {
            if (cutscene_time > 6f)
            {
                // Moving Left
                self.position = new Vector3(self.position.x - (Time.deltaTime * 3.5f), self.position.y, self.position.z);
                my_animator.speed = 1f;
            } else
            {
                // Moving Right
                self.position = new Vector3(self.position.x + Time.deltaTime, self.position.y, self.position.z);
                my_animator.speed = 0.5f;
            }
        } 

        if (cutscene_time > 3.5f && state == 0)
        {
            state = 1;
            my_animator.SetBool("IsMoving",false);
            moving = false;
            sub_sys.ShowDialouge(txt_1,"JACK");
        }

        if (cutscene_time > 4.5f && state == 1)
        {
            state = -2;
            sub_sys.ShowDialouge(txt_2,"JACK");
        }

        if (cutscene_time > 5.75f && state == -2)
        {
            state = 2;
            sub_sys.ConcludeDialouge();
        }

        if (cutscene_time > 8f && state == 2)
        {
            state = 3;
            sub_sys.ShowDialouge(txt_3,"JACK (THINKING)");
        }

        if (cutscene_time > 11f && state == 3)
        {
            state = 4;
            sub_sys.ShowDialouge(txt_4,"JACK");
        }

        if (cutscene_time > 11.2f)
        {
            sprite.localScale = new Vector3 (-1f, 1f, 1f);
            my_animator.SetBool("IsMoving",true);
            moving = true;
            fade_time += Time.deltaTime / 2.2f;
        }

        my_image.color = my_image.color = new Vector4(my_image.color.r, my_image.color.g, my_image.color.b, fade_time);

        if (fade_time > 1.1f && state == 4)
        {
            state = 5;
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}
