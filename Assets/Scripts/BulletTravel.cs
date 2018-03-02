using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public Vector3 direction { get; set; }
    public float speed { get; set; }

    void Update () {
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
	}
}
