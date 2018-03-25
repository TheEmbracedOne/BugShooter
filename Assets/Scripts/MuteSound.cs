using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour {


    //OnClick Sound enable toggle
    static bool isMute;
    public Sprite SoundOn;
    public Sprite SoundOff;

    void Start()
    {
        isMute = false;
        this.GetComponent<Button>().onClick.AddListener(Mute);
    }

    public void Mute()
    {
        isMute = !isMute;
        if(isMute)
        {
            AudioListener.volume = 0.0f;
            this.GetComponent<Image>().sprite = SoundOff;
        }
        else
        {
            AudioListener.volume = 1.0f;
            this.GetComponent<Image>().sprite = SoundOn;
        }
    }
}
