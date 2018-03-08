using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : BaseEnemy {
    
    private bool isDodging;
    private float dodgeTimer;

    public float maximumDistance;
    public float minimumDistance;
    public float speed;
    public float targetAngle;
    public float dodgingTime;
    public GameObject shootAction;

    public void Dodge()
    {
        if(dodgeTimer == default(float))
        {
            dodgeTimer = 0.0f;
        }
        isDodging = true;
    }

    public override void Move()
    {
        Vector2 movement;
        //Keep the distance or move to designated position
        if (Vector2.Distance(this.transform.position,player.transform.position) < minimumDistance)
        {
            movement = (this.transform.position - player.transform.position).normalized * speed;
        }
        else if (isDodging && dodgeTimer != 0.0f)
        {
            movement = this.GetComponent<Rigidbody2D>().velocity;
            dodgeTimer += Time.deltaTime;
            if (dodgeTimer > dodgingTime)
            {
                dodgeTimer = 0.0f;
                isDodging = false;
            }
        }
        else if(isDodging && dodgeTimer == 0.0f)
        {
            Vector2 vectorToPlayer = (player.transform.position - this.transform.position).normalized;
            
            Vector2 dodgeLeft =  new Vector2(-vectorToPlayer.y, vectorToPlayer.x) * speed;
            Vector2 dodgeRight = new Vector2(vectorToPlayer.y, -vectorToPlayer.x) * speed;
            if (new System.Random().Next(1,100) <= 50)
                movement = dodgeRight;
            else
                movement = dodgeLeft;

            dodgeTimer += Time.deltaTime;
        }
        else if(Vector2.Distance(this.transform.position, player.transform.position) > maximumDistance)
        {
            movement = (player.transform.position - this.transform.position).normalized * speed;
        }
        else
        {
            movement = new Vector2(0,0);
        }
        this.GetComponent<Rigidbody2D>().velocity = movement;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;

        float angle = Mathf.Atan2(player.transform.position.y - this.transform.position.y, player.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot()
    {
        foreach (SpriteAction sa in shootAction.GetComponentsInChildren<SpriteAction>()) sa.SetState(true);
        ps.Shoot(new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y).normalized, bulletSpeed, "EnemyBullet");
    }

    private Vector2 GetPlayerDirection()
    {
        float angle = player.transform.eulerAngles.z;
        float roundedAngle = angle - Mathf.FloorToInt(angle / 90) * 90; //282 -> 282 - floor(282 / 90 = 3) * 90 -> 12
        float x = Mathf.Sqrt(1 / (1 + Mathf.Pow(Mathf.Tan(roundedAngle), 2)));
        float y = x * Mathf.Tan(roundedAngle);
        if (angle <= 90f)
        {

            return new Vector2(x, y);
        }
        if (angle <= 180f)
        {
            return new Vector2(-y, x);
        }
        if (angle <= 270f)
        {
            return new Vector2(-x, -y);
        }
        if (angle <= 360f)
        {
            return new Vector2(y, -x);
        }
        return default(Vector2);
    }

    private Vector2 RotatePoint(Vector2 around, float angle, Vector2 point)
    {
        float sinusAngle = Mathf.Sin(angle);
        float cosinusAngle = Mathf.Cos(angle);

        Vector2 rotatedPoint = new Vector2();

        // translate point back to origin:
        rotatedPoint.x = point.x - around.x;
        rotatedPoint.y -= point.y - around.y;

        // rotate point
        float xnew = rotatedPoint.x * cosinusAngle - rotatedPoint.y * sinusAngle;
        float ynew = rotatedPoint.x * sinusAngle + rotatedPoint.y * cosinusAngle;

        // translate point back:
        rotatedPoint.x = xnew + around.x;
        rotatedPoint.y = ynew + around.y;
        return rotatedPoint;
    }
}
