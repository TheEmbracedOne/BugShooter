using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FlowController : MonoBehaviour {

    public FlowState _flowState;

    public FlowState flow
    {
        get { return _flowState; }
        set
        {
            Debug.LogFormat("set flow {0}", value);
            Debug.Log(System.Environment.StackTrace);

            flowObjects[(int)instance.flow].SetActive(false);
            _flowState = value;
            flowObjects[(int)instance.flow].SetActive(true);
            
        }
    }
    
    public GameObject[] flowObjects;

    public static FlowController instance;

    public void Awake()
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
        flow = (FlowState)((int)flow + 1);
        SaveFlowState();
    }

    public void SaveFlowState()
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
        
        string qFileName = flowObjects[(int)FlowState.PostPlayQuestionsStatic].GetComponent<Questionnare>().QuestionnareName;
        if (instance.flow < FlowState.DynamicPlay)
        {
            File.Delete(Application.dataPath + "/" + qFileName);
        }
        qFileName = flowObjects[(int)FlowState.PostPlayQuestionsDynamic].GetComponent<Questionnare>().QuestionnareName;
        if (instance.flow < FlowState.AfterGame)
        {
            File.Delete(Application.dataPath + "/" + qFileName);
        }
    }

    public void ActivateFlowState()
    {
        flowObjects[(int)instance.flow].SetActive(true);
    }
}

