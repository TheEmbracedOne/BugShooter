using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSession : MonoBehaviour {

    private static CloseSession instance;

    void Start()
    {
        if(instance == default(CloseSession))
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

	void OnDestroy()
    {
        if (instance == this)
        {
            Debug.Log("Destroying file dumper...");
            FileDump.CloseSessionFile();
        }
    }
}
