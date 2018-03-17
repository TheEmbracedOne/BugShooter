using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHit : MonoBehaviour {

    public string target;
    public string despawnTarget;
    public GameObject deathPrefab;

    /*public Sprite[] destroySpriteArray;
    public float timeInterval; //time between sprite changes

    private bool waiting;

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

    void OnDestroy()
    {
        this.GetComponent<SpriteCyclerStarter>().enabled = false;
        this.GetComponent<SpriteCycler>().enabled = false;

        foreach (WaitForSeconds s in DestroyIteration())
        {
        }
    }

    IEnumerable<WaitForSeconds> DestroyIteration()
    {
        foreach(Sprite s in destroySpriteArray)
        {
            this.GetComponent<SpriteRenderer>().sprite = s;
            yield return new WaitForSeconds(1.2f);
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag(target)) return;

        var damageTakers = other.gameObject.GetComponentsInChildren<DamageTaker>();
        foreach (DamageTaker dt in damageTakers) dt.takeDamage();

        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Instantiate(deathPrefab, transform.position, transform.rotation);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(despawnTarget)) Destroy(gameObject);
    }
}

