using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptDeleteB4Delivery : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(this.transform.rotation.z);
        }
	}
}
