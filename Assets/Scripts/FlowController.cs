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
        PostPlayQuestionsDual,
        AfterGame,
    }

    public FlowState GetFlowState()
    {
        return instance.flow;
    }

    public void SetFlowState(FlowState state)
    {
        instance.flow = state;
    }

    public void SetFlowState(int state)
    {
        instance.flow = (FlowState)state;
    }

    public void NextFlowState()
    {
        if (flow == FlowState.AfterGame) { return; }
        if(flow == FlowState.PostPlayQuestionsDual) { FileDump.CloseSessionFile(); }
        flow = (FlowState)((int)flow + 1);
        SaveFlowState();
        GameOverScreen.deathCount = 0;
    }

    public void SaveFlowState()
    {
        if (instance.flow == FlowState.PostPlayQuestionsDynamic || instance.flow == FlowState.PostPlayQuestionsStatic) { return; }
        string flowFile = Application.dataPath + "/flow.txt";
        StreamWriter sw = new StreamWriter(flowFile, false, System.Text.Encoding.ASCII);
        sw.WriteLine((int)instance.flow);
        sw.Close();
    }

    private void ReadFlowState()
    {
        string flowFile = Application.dataPath + "/flow.txt";
        if(!File.Exists(flowFile))
        {
            StreamWriter sw = new StreamWriter(flowFile, false, System.Text.Encoding.ASCII);
            sw.WriteLine("0");
            sw.Close();
        }
        StreamReader sr = new StreamReader(flowFile, System.Text.Encoding.ASCII);
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

