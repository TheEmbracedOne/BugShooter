using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyScore : MonoBehaviour, BountyTaker, DamageTaker
{
    public int currentBounty;

    public void addBounty(int b)
    {
        currentBounty += b;
        string[] message = { "Gained " + b + " bounty", currentBounty.ToString(), "DiffLvl" + SpawnScriptHandler.currentLevel.ToString()};
        FileDump.LogData(message);
    }

    public void takeDamage()
    {
        takeDamage(1);
    }

    public void takeDamage(int dmg)
    {
        if (currentBounty > 0)
        {
            currentBounty-= dmg;
            string[] message = { "Lost " + dmg + " bounty", currentBounty.ToString(), "DiffLvl" + SpawnScriptHandler.currentLevel.ToString() };
            FileDump.LogData(message);
        }
    }
}
