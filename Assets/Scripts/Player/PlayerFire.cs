using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {
    public float fireRate;
    public float bulletSpeed;
    public GameObject shootAction;
    public AudioClip BulletShootSound;
    public AudioSource audioSrc;

    private float fireCounter;
    private ProjectileSpawner ps;

    void Start () {
        fireCounter = fireRate;
        ps = this.GetComponent<ProjectileSpawner>();
    }
	
	void Update () {
        if (fireCounter >= fireRate)
        {
            ps.CreateProjectile();
            if (Input.GetButton("Fire1"))
            {
                foreach (SpriteAction sa in shootAction.GetComponentsInChildren<SpriteAction>()) sa.SetState(true);
                Vector3 pos =  Camera.main.WorldToScreenPoint(this.transform.position);
                Vector3 direction = new Vector3(Input.mousePosition.x - pos.x, Input.mousePosition.y - pos.y, 0).normalized;

                ps.Shoot(direction, bulletSpeed, "PlayerBullet");
                audioSrc.PlayOneShot(BulletShootSound);

                fireCounter = 0;
            }
        }
        fireCounter += Time.deltaTime;
    }
}
