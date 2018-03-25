using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQuery : MonoBehaviour {

    public GameObject WinScreen;
    public float timeInterval;
    private float timeSpent;

    void Start()
    {
        this.enabled = false;
        timeSpent = 0;
    }

    void Update () {
        timeSpent += Time.deltaTime;
        if(timeSpent >= timeInterval)
        {
            GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in EnemyList) { if (go.activeSelf) return; }
            //call win screen here
            WinScreen.SetActive(true);
            timeSpent = 0;
        }
        
    }
}
