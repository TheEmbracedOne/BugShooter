using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPostGame : MonoBehaviour
{

    public FlowController.FlowState SceneToLoad;

    /* public void LoadingScene()
     {
         if (GetKeyCodeDown)

         FlowController.instance.SetFlowState();
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
     */

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            //Menu.SetActive(true);
            Debug.Log("Menu loaded.");
            FlowController.instance.SetFlowState(SceneToLoad);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}