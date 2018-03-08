using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponentInParent<HardEnemy>().Dodge();
    }
}
