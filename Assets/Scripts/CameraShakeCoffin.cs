using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeCoffin : MonoBehaviour
{

    public Vector3 target_position;
    
    public float speed;
    
    public Transform self;

    public Rigidbody2D my_body;

    public Camera cam;

    public AnimationCurve ortho_size;
    public AnimationCurve height;

    public float eval;

    public ShakeOut shake;

    public float time_since_automation;
    public int automation;

    public GameObject text_1;
    public GameObject text_2;
    public GameObject text_3;
    public GameObject text_4;
    public GameObject text_5;
    public GameObject text_6;
    public GameObject text_7;

    public bool autonomous;
    public bool in_middle;

    public Vector3 mid;

    public float ejection_time;
    public VHS_Exit exit;
    public GameObject flash;
    public bool flash_bool;

    void PageFlip()
    {
        automation += 1;

        text_1.SetActive(false);
        text_2.SetActive(false);
        text_3.SetActive(false);
        text_4.SetActive(false);
        text_5.SetActive(false);
        text_6.SetActive(false);
        text_7.SetActive(false);

        if (automation == 1) {text_1.SetActive(true);}
        if (automation == 2) {text_2.SetActive(true);}
        if (automation == 3) {text_3.SetActive(true);}
        if (automation == 4) {text_4.SetActive(true);}
        if (automation == 5) {text_5.SetActive(true);}
        if (automation == 6) {text_6.SetActive(true);}
        if (automation == 7) {text_7.SetActive(true);}

    }

    // Start is called before the first frame update
    void Start()
    {
        target_position = self.position;
        automation = -1;
        PageFlip();
        flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (automation > 7)
        {
            ejection_time += Time.deltaTime;
        }

        if (ejection_time > 3.3f)
        {
            if (Random.Range(1,4) == 1)
            {
                flash_bool = !flash_bool;
                flash.SetActive(flash_bool);
            }
        }

        if (ejection_time > 4.5f)
        {
            exit.switch_scenes();
        }

        autonomous = shake.autonomous;

        Vector3 desiredPosition = target_position;
        Vector3 smoothedPosition = Vector3.Lerp(self.position, desiredPosition, speed);
        self.position = smoothedPosition;

        if (autonomous)
        {
            if (!in_middle)
            {
                in_middle = true;
                self.position = mid;
            }
            time_since_automation += Time.deltaTime;
            if (time_since_automation > 2.5f)
            {
                PageFlip();
                time_since_automation = 0f;
            }
        }

        if (my_body.velocity.x > 0.2f)
        {
            my_body.velocity = new Vector2 (my_body.velocity.x - (Time.deltaTime * 1f), my_body.velocity.y);
        }

        if (my_body.velocity.x < -0.2f)
        {
            my_body.velocity = new Vector2 (my_body.velocity.x + (Time.deltaTime * 1f), my_body.velocity.y);
        }

        eval = my_body.velocity.x;
        if (eval < 0f)
        {
            eval = eval * -1f;
        }
        cam.orthographicSize = ortho_size.Evaluate(eval);
        target_position.y = height.Evaluate(eval);

    }
}
