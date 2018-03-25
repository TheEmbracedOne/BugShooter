using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {
    public string QuestionText;

    private bool FadeIn;
    private bool FadeOut;
    private Image blackScreen;

    private float PreviousAlpha;

    void Start()
    {
        PreviousAlpha = 0.0f;
        blackScreen = GameObject.FindWithTag("BlackScreen").GetComponent<Image>();
    }

    void OnEnable()
    {
        FadeIn = true;
    }

    void Update()
    {
        if (FadeIn || FadeOut)
        {
            PreviousAlpha = blackScreen.color.a;
            
            if (FadeIn)
            {
                
                blackScreen.color = new Color(0, 0, 0, PreviousAlpha + 0.12f);
                if (blackScreen.color.a >= 250.0f/255.0f)
                {
                    FadeIn = false;
                    FadeOut = true;
 
                }
            }
            if (FadeOut)
            {
                blackScreen.color = new Color(0, 0, 0, PreviousAlpha - 0.12f);
                if (blackScreen.color.a <= 5.0f/255.0f)
                {
                    FadeIn = false;
                    FadeOut = false;
                }
            }
            
        }
    }
}
