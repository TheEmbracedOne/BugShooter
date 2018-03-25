using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptDeleteB4Delivery : MonoBehaviour
{

    void OnDestroy()
    {
        FlowController.instance.NextFlowState();
        /* if (Input.GetKeyDown(KeyCode.F9))
         {

         }
     }*/
    }
}