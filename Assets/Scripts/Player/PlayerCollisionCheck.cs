using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") == true)
        {
            Object.Destroy(other.gameObject);
            foreach (DamageTaker dt in this.gameObject.GetComponentsInChildren<DamageTaker>())
            {
                dt.takeDamage();
            }
        }
    }
}
