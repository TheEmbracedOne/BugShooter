using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour, DamageTaker
{
    public int HealthPoints;

    public void takeDamage() { takeDamage(1); }
    public void healDamage() { healDamage(1); }

    public void takeDamage(int i)
    {
        //Debug.Log("EntityHealth takeDamage called");
        HealthPoints -= i;
        if (HealthPoints <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void healDamage(int i)
    {
        HealthPoints += i;
    }
}
