using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MustHaveValue : MonoBehaviour
{
    public bool hasValue;

    public void checkValue()
    {
        foreach(Text t in this.GetComponentsInChildren<Text>())
        {
            if(t.text.Equals(""))
            {
                hasValue = false;
                return;
            }
        }
        hasValue = true;
        this.transform.parent.GetComponentInChildren<CheckValues>().EnableButton();
    }
}
