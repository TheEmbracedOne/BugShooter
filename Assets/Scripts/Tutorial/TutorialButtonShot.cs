using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonShot : MonoBehaviour {

    public GameObject HitTarget;
    public GameObject NextUp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            HitTarget.SetActive(false);
            NextUp.SetActive(true);
            Debug.Log("Button shot");
        }
    }

}

