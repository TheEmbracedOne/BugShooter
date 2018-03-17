using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPlayerShield : MonoBehaviour, BountyTaker, DamageTaker
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
    // if damage done (bounty +1) but no damage taken (bounty -1), get shield + 1 degree
    // if damage taken (bounty -1), shield -3 degree


    // if shield ShieldMax, gain ShieldOn
    // if ShieldOn, when facing enemy directon and OnColliderEnter, enemy.destroy
    // if ShieldOn and damage taken (bounty -1), shield -10 degree 

        //PlayerShield -> PlayerShieldSide

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
    
}
