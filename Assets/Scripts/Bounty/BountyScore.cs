﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyScore : MonoBehaviour, BountyTaker, DamageTaker
{
    public int currentBounty;

    public void addBounty(int b)
    {
        currentBounty += b;
        string[] message = { "Gained " + b + " bounty", "B" + currentBounty.ToString(), "L" + SpawnScriptHandler.currentLevel.ToString()};
        FileDump.LogData(message);
    }

    public void takeDamage()
    {
        if(currentBounty > 0)
        {
            currentBounty--;
            string[] message = { "Lost 1 bounty", currentBounty.ToString() };
            FileDump.LogData(message);
        }
    }
}
