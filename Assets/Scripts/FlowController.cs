using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FlowController : MonoBehaviour {

    private FlowState flow;
    public GameObject[] flowObjects;

    public static FlowController instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            ReadFlowState();
            ActivateFlowState();
        }
        else
        {
            Destroy(this);
        }
    }

	public enum FlowState
    {
        Disclaimer,
        Tutorial,
        PrePlayQuestions,
        StaticPlay,
        PostPlayQuestionsStatic,
        DynamicPlay,
        PostPlayQuestionsDynamic,
        AfterGame
    }

    public FlowState GetFlowState()
    {
        return instance.flow;
    }

    public void SetFlowState(FlowState state)
    {
        instance.flow = state;
    }

    public void NextFlowState()
    {
        if (flow == FlowState.AfterGame) { return; }
        flowObjects[(int)instance.flow].SetActive(false);
        flowObjects[(int)instance.flow + 1].SetActive(true);
        flow = (FlowState)((int)flow + 1);
        SaveFlowState();
    }

    private void SaveFlowState()
    {
        if (instance.flow == FlowState.PostPlayQuestionsDynamic || instance.flow == FlowState.PostPlayQuestionsStatic) { return; }
        string flowFile = Application.dataPath + "/flow.txt";
        StreamWriter sw = new StreamWriter(flowFile, false, System.Text.Encoding.UTF8);
        sw.WriteLine((int)instance.flow);
        sw.Close();
    }

    private void ReadFlowState()
    {
        string flowFile = Application.dataPath + "/flow.txt";
        if(!File.Exists(flowFile))
        {
            StreamWriter sw = new StreamWriter(flowFile, false, System.Text.Encoding.UTF8);
            sw.WriteLine("0");
            sw.Close();
        }
        StreamReader sr = new StreamReader(flowFile, System.Text.Encoding.UTF8);
        instance.flow = (FlowState)int.Parse(sr.ReadLine());
        sr.Close();
    }

    private void ActivateFlowState()
    {
        flowObjects[(int)instance.flow].SetActive(true);
    }
}

