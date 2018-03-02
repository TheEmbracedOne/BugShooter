﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ProjectileSpawner))]
public abstract class BaseEnemy : MonoBehaviour, Enemy, DamageTaker
{
    public float bulletSpeed;
    protected float fireCounter;

    public float fireRate;
    public int bounty;

    protected GameObject player;
    protected ProjectileSpawner ps;

    // Use this for initialization
    void Start()
    {
        fireCounter = fireRate;
        ps = this.GetComponentInChildren<ProjectileSpawner>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (fireCounter >= fireRate)
        {
            Shoot();
            fireCounter = 0;
        }

        fireCounter += Time.deltaTime;
    }

    public abstract void Move();
    public abstract void Shoot();

    public void takeDamage()
    {
        if (player != null)
        {
            foreach (BountyTaker bt in player.gameObject.GetComponentsInChildren<BountyTaker>())
            {
                bt.addBounty(1);
            }
        }
    }

    void OnDestroy()
    {
        if (player != null)
        {
            foreach (BountyTaker bt in player.gameObject.GetComponentsInChildren<BountyTaker>())
            {
                bt.addBounty(bounty);
            }
        }
    }
}
