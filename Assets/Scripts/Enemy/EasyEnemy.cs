using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemy : BaseEnemy {

    public Vector2 direction;
    public float speed;

    public override void Move()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 movement = this.transform.right.normalized * speed;
        this.GetComponent<Rigidbody2D>().velocity = movement;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }

    public override void Shoot()
    {
        //this.transform.Rotate(0, 0, 90, Space.Self);        
        ps.CreateProjectile();
        ps.Shoot(new Vector2(-1 * direction.y, direction.x), bulletSpeed, "EnemyBullet");
    }
}
