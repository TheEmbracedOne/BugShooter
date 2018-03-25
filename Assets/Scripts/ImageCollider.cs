using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCollider : MonoBehaviour {

    private GameObject player;
    //public AudioClip ShieldSplash;
    //public AudioSource audioSrc;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    static bool AngleBetween(float a, float b, float g)
    {
        if (a <= b)
            if (b - a <= Mathf.PI) //Why not 180f?
                return a <= g && g <= b;
            else
                return b <= g || g <= a;

        if (a - b <= Mathf.PI) //Why not 180f?
            return b <= g && g <= a;
        return a <= g || g <= b;
    }

    static float NormalizeAngle(float a)
    {
        a = a % 360;
        if (a >= 180) return a - 360;
        if (a < -180) return a + 360;
        return a;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("EnemyBullet")) return;

        Vector2 direction = -(other.transform.position - transform.position).normalized;
        float playerAngle = player.transform.eulerAngles.z;

        float shield = this.GetComponentInParent<PlayerShield>().currentShield * 1.8f; // calculate shield size in degrees here

        float a = playerAngle + shield;
        float b = playerAngle - shield;

        // normalize and convert to radians
        a = NormalizeAngle(a) * Mathf.Deg2Rad;
        b = NormalizeAngle(b) * Mathf.Deg2Rad;

        // did it hit our shield?
        if (AngleBetween(a, b, Mathf.Atan2(direction.y, direction.x)))
        {
            //Debug.Log("hit shield!"); 
            //this.GetComponentInParent<AudioSource>().PlayOneShot(ShieldSplash);
            Destroy(other.gameObject);
        }
            
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        //Ennek 33-nak kellene lennie... :(
        //hm... van olyan method amivel ellenőrizni tudjuk hogy még itt van...?hogy erted hogy "itt van"?
        //ami 'Enter' utan meg exit kozott ellenorzi a bulletet | jo kerdes, nem vagyok iztos benne nézem a dokumentaciot pill
        if(other.CompareTag("EnemyBullet") == true &&
             Quaternion.Angle(other.transform.rotation, player.transform.rotation) < 
             this.GetComponent<PlayerShield>().currentShield * 3.6f)
        {
            Object.Destroy(other.gameObject);
        }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            //x - x0 / y - y0 > cotangens(angle)
            //y-y0 > 0
            //(x-x0) ^ 2 + (y-y0) ^ 2 < r ^ 2 - implicit, mert a körben kell lennie hogy az OnTriggerStay meghívódjon
            //elforgatjuk a collider other-t a kör középpontja körül (180 + angle) / 2 -vel és ha megfelel a harom fenti feltetelnek akkor shield védi.
            Vector2 referencePoint = RotateAroundPoint(other.transform.position, this.transform.position, Vector2.Angle(player.transform.right, Vector2.up) + 90);
            if (((referencePoint.x - this.transform.position.x) / (referencePoint.y - this.transform.position.y)) > (1 / Mathf.Tan(this.GetComponent<PlayerShield>().currentShield * 3.6f * Mathf.Deg2Rad)) &&
                referencePoint.y - this.transform.position.y > 0)
            {
                Debug.Log("Projectile hits shield!");
                Destroy(other.gameObject);
            }
        }
    }
	
    Vector2 RotateAroundPoint(Vector2 pointToRotate, Vector2 pointAround, float angleInDegrees)
    {
        Vector2 returnVector = new Vector2(pointToRotate.x, pointToRotate.y);
        float sinus = Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
        float cosinus = Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);

        returnVector.x -= pointAround.x;
        returnVector.y -= pointAround.y;

        float newX = returnVector.x * cosinus - returnVector.y * sinus;
        float newY = returnVector.x * sinus + returnVector.y * cosinus;

        returnVector.x = newX + pointAround.x;
        returnVector.y = newY + pointAround.y;
        return returnVector;
    }
    

    bool isBetween(float value, float border1, float border2)
    {
        if(border1 > border2)
        {
            return (border2 < value && value < border1);
        }
        else
        {
            return (border1 < value && value < border2);
        }
    }*/


}
