using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ForceSaveFLowState : MonoBehaviour {

    public string FlowToSave;
  

    void Awake () {
        string flowFile = Application.dataPath + "/flow.txt";
        StreamWriter sw = new StreamWriter(flowFile, false, System.Text.Encoding.UTF8);
        sw.WriteLine(FlowToSave);
        sw.Close();
    }
	

}
