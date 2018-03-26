using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonShotShot : MonoBehaviour
{
    public GameObject NextUp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            NextUp.SetActive(true);
            this.gameObject.SetActive(false);
            //Debug.Log("Button shot");
        }
    }

}

