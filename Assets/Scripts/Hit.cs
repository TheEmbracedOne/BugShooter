using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public string target;
    public string despawnTarget;
    public string shieldTarget;
    public GameObject deathPrefab;
    public AudioClip ShieldSplash;
    public AudioSource AudioSource;




    void OnTriggerEnter2D(Collider2D other)
    {

        /*if (other.gameObject.CompareTag(shieldTarget))
        {
            AudioSource.PlayOneShot(ShieldSplash);
        }*/

        if (!other.gameObject.CompareTag(target)) return;
       
        var damageTakers = other.gameObject.GetComponentsInChildren<DamageTaker>();
        foreach (DamageTaker dt in damageTakers) dt.takeDamage();
        Instantiate(deathPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(despawnTarget)) Destroy(gameObject);
    }
}

