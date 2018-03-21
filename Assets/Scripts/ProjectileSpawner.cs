using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform preFab;
    public GameObject positionerObject;


    private Transform bullet;

    void Start()
    {
        bullet = null;
    }

    public void CreateProjectile()
    {
        CreateProjectile(new Quaternion(0, 0, positionerObject.transform.rotation.z, positionerObject.transform.rotation.w));
        
    }

    public void CreateProjectile(Quaternion pRotation)
    {
        if (bullet == null)
        {
            bullet = Transform.Instantiate(preFab, positionerObject.transform.position, pRotation);
            bullet.transform.SetParent(positionerObject.transform);
            bullet.GetComponent<Collider2D>().enabled = false;
           
        }
    }

    public void Shoot(Vector3 direction, float bulletSpeed, string tag)
    {
        if(bullet == null)
        {
            throw new UnassignedReferenceException("No bullet to shoot!");
        }
        bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        bullet.GetComponent<BulletTravel>().direction = direction;
        bullet.GetComponent<BulletTravel>().speed = bulletSpeed;
        bullet.tag = tag;
        bullet.GetComponent<Collider2D>().enabled = true;
        bullet = null;
        
    }
}
