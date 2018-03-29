using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour, BountyTaker, DamageTaker
{
    public float ShieldMax;
    private float _shield;
    public float currentShield
    {
        get { return _shield; }
        set { _shield = value; shieldLeft.fillAmount = value / 200; shieldRight.fillAmount = value / 200; }
    }
    public Image shieldLeft;
    public Image shieldRight;
    public void addBounty(int b)
    {
        if (currentShield < ShieldMax)
        {
            this.GetComponent<EntityHealth>().healDamage();
            currentShield++;
        }
    }

    public void takeDamage()
    {
        currentShield -= 1;        
    }

    void Start()
    {
        currentShield = this.GetComponent<EntityHealth>().HealthPoints;
    }

    public void takeDamage(int dmg)
    {
        currentShield -= dmg;
    }
}
