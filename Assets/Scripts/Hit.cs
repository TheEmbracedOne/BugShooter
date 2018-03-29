using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public string target;
    public string despawnTarget;
    public GameObject deathPrefab;
    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(target)) return;

        if (other.gameObject.CompareTag(target))
        {
            DamageTaker[] damageTakers = other.gameObject.GetComponentsInChildren<DamageTaker>();
            foreach (DamageTaker dt in damageTakers) dt.takeDamage(damage);
            Instantiate(deathPrefab, this.transform.position, this.transform.rotation);
            Destroy(gameObject);
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(despawnTarget)) Destroy(gameObject);
    }
}

