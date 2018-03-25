using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public FlowController.FlowState SceneToLoad;

    public void LoadingScene()
    {
        FlowController.instance.SetFlowState(SceneToLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

