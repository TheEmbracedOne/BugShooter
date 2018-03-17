using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplash : MonoBehaviour {

    public float DestroyAfter;
    
    void Awake()
    {
        //StartCoroutine(ActivationRoutine());
        Destroy(gameObject, DestroyAfter);
    }

    void Update()
    {

    }
}

