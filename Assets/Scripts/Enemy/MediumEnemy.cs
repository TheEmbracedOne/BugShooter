using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : BaseEnemy {

    private Vector2 previousPosition;
    public float speed;
    public float spiral;
    public float reverseDistance;
    public GameObject shootAction;

    public override void Move()
    {
        float angle = Mathf.Atan2(player.transform.position.y - this.transform.position.y, player.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 toPlayer = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
        
        Vector2 movement = new Vector2(this.transform.right.normalized.x + this.transform.up.normalized.x * spiral, this.transform.right.normalized.y + this.transform.up.normalized.y * spiral) * speed;
        this.GetComponent<Rigidbody2D>().velocity = movement;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    public override void Shoot()
    {      
        if(previousPosition != null && Vector2.Distance(this.transform.position, previousPosition) < reverseDistance)
        {
            spiral *= -1;
        }
        foreach (SpriteAction sa in shootAction.GetComponentsInChildren<SpriteAction>()) sa.SetState(true);

        ps.Shoot(new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y).normalized, bulletSpeed, "EnemyBullet");
        previousPosition = this.transform.position;
    }
}
