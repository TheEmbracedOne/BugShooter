using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour, DamageTaker
{
    public int HealthPoints;

    public void takeDamage()
    {
        HealthPoints--;
        if (HealthPoints == 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
