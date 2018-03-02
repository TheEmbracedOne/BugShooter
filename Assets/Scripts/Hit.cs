using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    public string target;
    public string despawnTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.CompareTag(target) == true)
        {
            foreach (DamageTaker dt in other.gameObject.GetComponentsInChildren<DamageTaker>())
            {
                dt.takeDamage();
            }
            Object.Destroy(this.gameObject);
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(despawnTarget))
        {
            Object.Destroy(this.gameObject);
        }
    }
}
