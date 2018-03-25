using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    private bool isQuitting;
    public GameObject gameOverScreen;
    public GameObject questionButton;
    public static int deathCount;

    void Start()
    {
        if(deathCount == default(int))
        {
            deathCount = 0;
        }
        isQuitting = false;
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

	void OnDestroy()
    {
        deathCount++;
        if (!isQuitting)
        {
            gameOverScreen.SetActive(true);
            if(deathCount >= 3)
            {
                questionButton.SetActive(true);
            }
        }
    }
}
