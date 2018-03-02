using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CheckValues : MonoBehaviour
{
    public int eventQueueSize;
    private Button reinforcedButton;

    void Start()
    {
        reinforcedButton = this.GetComponent<Button>();
        EnableButton();
    }

    public bool checkValues()
    {
        foreach(MustHaveValue mhv in this.GetComponentInParent<Canvas>().gameObject.GetComponentsInChildren<MustHaveValue>())
        {
            if(mhv.hasValue == false)
            {
                return false;
            }
        }
        return true;
    }

    public void EnableButton()
    {
        UnityEventCallState callState;
        if(checkValues() == false)
        {
            callState = UnityEventCallState.Off;
        }
        else
        {
            callState = UnityEventCallState.RuntimeOnly;
        }
        for(int i = 0; i < eventQueueSize; i++)
        {
            reinforcedButton.onClick.SetPersistentListenerState(i, callState);
        }
    }
}
