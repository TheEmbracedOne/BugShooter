using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplash : MonoBehaviour {

    public float DestroyAfter;
    public AudioClip BulletExplodeSound;
    public AudioSource AudioSource;

    void Awake()
    {
        AudioSource.PlayOneShot(BulletExplodeSound);
        //StartCoroutine(ActivationRoutine());
        Destroy(gameObject, DestroyAfter);
    }

    void Update()
    {

    }
}

