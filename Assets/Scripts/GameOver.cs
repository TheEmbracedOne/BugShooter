using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void OnGameOver ()
    {
        FlowController.instance.SaveFlowState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //FlowController.instance.SetFlowState;
        //File.WriteAllText(Path.Combine(Application.dataPath, "flow.txt"), instance.flow.ToString());
     }
}

