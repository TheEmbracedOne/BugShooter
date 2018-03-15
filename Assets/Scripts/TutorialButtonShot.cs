using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonShot : MonoBehaviour {

    public GameObject HitTarget;
    public GameObject NextUp;

    void OnCollider2D(Collider2D other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(HitTarget);
            NextUp.SetActive(true);
            Debug.Log("Button shot");
        }
    }

}

