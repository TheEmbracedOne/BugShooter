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
    public float shootAngle;
    public float shootAngleVariation;
    private bool shootState;
    

    public override void Move()
    {
        if(player != null)
        {
            float angle = Mathf.Atan2(player.transform.position.y - this.transform.position.y, player.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0, 0, angle);

            Vector2 movement = new Vector2(this.transform.right.normalized.x + this.transform.up.normalized.x * spiral, this.transform.right.normalized.y + this.transform.up.normalized.y * spiral) * speed;
            this.GetComponent<Rigidbody2D>().velocity = movement;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0 , 0);
            this.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
        }
        
    }

    public override void Shoot()
    {
        if(player != null)
        {
            if (previousPosition != default(Vector2) && Vector2.Distance(this.transform.position, previousPosition) < reverseDistance)
            {
                spiral *= -1;
            }
            foreach (SpriteAction sa in shootAction.GetComponentsInChildren<SpriteAction>()) sa.SetState(true);
            Vector2 shootingVector = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y).normalized;
            //Debug.Log("At mid: " + shootAngle);
            ps.Shoot(shootingVector, bulletSpeed, "EnemyBullet");

            // - shootAngle
            Vector2 shootingVectorRight = new Vector2(Mathf.Cos(Mathf.Deg2Rad * shootAngle) * shootingVector.x - Mathf.Sin(Mathf.Deg2Rad * shootAngle) * shootingVector.y,
            Mathf.Sin(Mathf.Deg2Rad * shootAngle) * shootingVector.x + Mathf.Cos(Mathf.Deg2Rad * shootAngle) * shootingVector.y).normalized;
            ps.CreateProjectile();
            //Debug.Log("At right: " + shootAngle);
            ps.Shoot(shootingVectorRight, bulletSpeed, "EnemyBullet");

            // + shootAngle
            Vector2 shootingVectorLeft = new Vector2(Mathf.Cos(Mathf.Deg2Rad * shootAngle) * shootingVector.x + Mathf.Sin(Mathf.Deg2Rad * shootAngle) * shootingVector.y,
            -1 * Mathf.Sin(Mathf.Deg2Rad * shootAngle) * shootingVector.x + Mathf.Cos(Mathf.Deg2Rad * shootAngle) * shootingVector.y).normalized;
            ps.CreateProjectile();
            //Debug.Log("At left: " + shootAngle);
            ps.Shoot(shootingVectorLeft, bulletSpeed, "EnemyBullet");
            if (shootState == default(bool)) shootState = false;
            if (shootState)
            {
                shootAngle = shootAngle - shootAngleVariation;
            }
            else
            {
                shootAngle = shootAngle + shootAngleVariation;
            }
            shootState = !shootState;
            previousPosition = this.transform.position;
        }
        
    }
}
