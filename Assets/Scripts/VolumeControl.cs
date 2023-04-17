using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    public Slider the_slider;
    public SaveSystem the_sys;

    public void Start()
    {
        the_slider.value = Mind.volume;
    }

    public void UpdatedVolume()
    {
        Mind.volume = the_slider.value;
        the_sys.SaveSystem_SAVE();
    }

}
