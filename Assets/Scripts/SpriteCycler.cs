using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCycler : MonoBehaviour, SpriteAction
{
    
    public float timeInterval; //time between sprite changes
    private float timeBetweenCycle;

    private bool isWindingUp;
    private bool isWindingDown;

    public Sprite[] windUpSpriteArray;
    public Sprite[] spriteArray;
    public SpriteRenderer render;

    private bool isEnabled; //starts disabled
    private int cycleCounter; //starts at 0 and cycles through the sprite array
    private int windingCycleCounter;

    void Start()
    {
        isEnabled = false;
        isWindingDown = false;
        isWindingUp = false;
        cycleCounter = 0;
        windingCycleCounter = 0;
        timeBetweenCycle = 0.0f;
    }

    public void SetState(bool enableStatus)
    {
        isEnabled = enableStatus;
        isWindingUp = enableStatus;
        isWindingDown = !isWindingUp;
        if (isWindingUp) windingCycleCounter = 0; else windingCycleCounter = windUpSpriteArray.Length - 1;
    }

    //This is called from another MonoBehaviour's Update without enabling the cycling.
    

    //This will automatically cycle through the sprites, including a single wind-up and a single wind-down cycle.
    void Update()
    {
        if(isEnabled || isWindingDown || isWindingUp)
        {
            timeBetweenCycle += Time.deltaTime;
            if(timeBetweenCycle > timeInterval)
            {
                if(isWindingUp)
                {
                    if(windingCycleCounter < windUpSpriteArray.Length)
                    {
                        render.sprite = windUpSpriteArray[windingCycleCounter];
                        windingCycleCounter += 1;
                    }
                    else
                    {
                        windingCycleCounter -= 1;
                        isWindingUp = false;
                    }
                }
                if(isEnabled && !isWindingUp)
                {
                    if(spriteArray.Length == 0)
                    {
                        isEnabled = false;
                        isWindingDown = true;
                    }
                    else
                    {
                        render.sprite = spriteArray[cycleCounter];
                        cycleCounter = ((cycleCounter + 1) % spriteArray.Length);
                    }
                }
                if(isWindingDown)
                {
                    if(windingCycleCounter >= 0)
                    {
                        render.sprite = windUpSpriteArray[windingCycleCounter];
                        windingCycleCounter -= 1;
                    }
                    else
                    {
                        windingCycleCounter = 0;
                        isWindingDown = false;
                    }
                }
                timeBetweenCycle = 0.0f;
            }
        }
    }

    public bool IsEnabled()
    {
        return isEnabled;
    }
    //public array size: WingCover
    //public array: WingCover
    //public array size: Wings
    //public array: Wings
    //public time interval

    //public moving?
    //public stopping?


    //void WingMovement: wing covers open, wings flap while moving, close when movement stops
    //if moving
    //wingcovers change sprite 2-3-4 order then keep changing 3-4-3-4-...
    //wings change sprite 1-2-3-4 order then keep changing 3-4-3-4-...

    //if stopping
    //wingcovers change sprite 2-1
    //wings change sprite 2-1

}




