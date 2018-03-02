using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour, BountyTaker, DamageTaker
{
    public float ShieldMax;
    public float currentShield;
    private Image shield;
    // if damage done (bounty +1) but no damage taken (bounty -1), get shield + 1 degree
    // if damage taken (bounty -1), shield -3 degree


    // if shield ShieldMax, gain ShieldOn
    // if ShieldOn, when facing enemy directon and OnColliderEnter, enemy.destroy
    // if ShieldOn and damage taken (bounty -1), shield -10 degree 

    public void addBounty(int b)
    {
        if(currentShield < ShieldMax)
        {
            currentShield++;
            shield.fillAmount = currentShield / 200;
        }
    }

    public void takeDamage()
    {
        if (currentShield >= 3)
        {
            currentShield -= 3;
        }
        else
        {
            currentShield = 0;
        }
        shield.fillAmount = currentShield / 200;
    }

    void Start () {
        shield = this.GetComponent<Image>();

        shield.fillAmount = currentShield / 200;
    }
}
