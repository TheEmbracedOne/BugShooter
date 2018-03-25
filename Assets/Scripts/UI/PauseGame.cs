using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public GameObject PauseScreen;
    private bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ChangePauseState();
            Debug.Log("Esc pressed");
        }
    }

    public void ChangePauseState()
    {
        if (isPaused)
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
        isPaused = !isPaused;
    }
	//upon hitting Esc bring up menu
    //time.deltatime = 0

    //upon hitting Esc again or button, hide, time.deltatime = 1 

}
