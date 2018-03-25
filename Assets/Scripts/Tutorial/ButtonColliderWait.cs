using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColliderWait : MonoBehaviour {

    void Awake ()
    {
        StartCoroutine(ActivationRoutine());

    }
	
	void Update () {
		
	}

    private IEnumerator ActivationRoutine()
    {
        //Wait for 5 secs.
        yield return new WaitForSeconds(2);

        //Turn My game object that is set to false(off) to True(on).
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
