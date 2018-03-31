using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public string target;
    //public GameObject targetObject;
    public string despawnTarget;
    public GameObject deathPrefab;
    public int damage;
    
    //public float spriteBlinkingTimer = 0.0f;
    //public float spriteBlinkingMiniDuration = 0.1f;
    //public float spriteBlinkingTotalTimer = 0.0f;
    //public float spriteBlinkingTotalDuration = 1.0f;
    //public bool startBlinking = false;
    
    
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


    //Flash Effect
    /*private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            targetObject.gameObject.GetComponent<SpriteRenderer>().enabled = true;    
                                                                             
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (targetObject.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                targetObject.gameObject.GetComponent<SpriteRenderer>().enabled = false;  
            }
            else
            {
                targetObject.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }


    }*/
}

