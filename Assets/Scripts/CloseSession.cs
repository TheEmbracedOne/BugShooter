using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSession : MonoBehaviour {

	void OnDisable()
    {
        FileDump.CloseSessionFile();
    }
}
