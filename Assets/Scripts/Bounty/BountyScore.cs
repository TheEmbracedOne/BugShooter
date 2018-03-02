using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyScore : MonoBehaviour, BountyTaker, DamageTaker
{
    public int currentBounty;

    public void addBounty(int b)
    {
        currentBounty += b;
    }

    public void takeDamage()
    {
        if(currentBounty > 0)
        {
            currentBounty--;
        }
    }
}
