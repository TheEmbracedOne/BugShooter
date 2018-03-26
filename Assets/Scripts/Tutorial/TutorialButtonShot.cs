using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonShot : MonoBehaviour {

    public GameObject flowController;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            flowController.GetComponent<FlowController>().NextFlowState();
            //Debug.Log("Button shot");
        }
    }

}

