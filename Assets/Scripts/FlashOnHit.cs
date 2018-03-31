using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlashOnHit : MonoBehaviour, DamageTaker {
    private bool takingDamage;
    private float damageTimer;
    public float damageTime;

    // Use this for initialization
    void Start () {
        takingDamage = false;
        damageTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (takingDamage)
        {
            if (damageTimer < damageTime)
            {
                damageTimer += Time.deltaTime;
                float nonRedComponent = -Mathf.Sin(damageTimer * Mathf.PI / damageTime);

                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    if (sr.gameObject.CompareTag("EnemyBullet") == false)
                    {
                        sr.color = new Color(1, nonRedComponent, nonRedComponent);
                    }
                }
                GetComponent<SpriteRenderer>().color = new Color(1, nonRedComponent, nonRedComponent);
            }
            else
            {
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.color = new Color(1, 1, 1);
                }
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                takingDamage = false;
                damageTimer = 0;
            }
        }
    }

    public void takeDamage()
    {
        takingDamage = true;
    }

    public void takeDamage(int dmg)
    {
        takeDamage();
    }
}
