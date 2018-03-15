using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptDeleteB4Delivery : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            FlowController.instance.NextFlowState();
        }
    }
}
