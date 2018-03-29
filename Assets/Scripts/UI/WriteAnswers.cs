using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WriteAnswers : MonoBehaviour {

    public Text AnswerText;
    private Questionnare questionnare;

    private string qText;
    private string aText;

    void Start()
    {
        questionnare = GetComponentInParent<Questionnare>();
        qText = this.GetComponentInParent<Question>().QuestionText;
    }

    void Update()
    {
        aText = AnswerText.text;
    }

    public void Submit()
    {
        questionnare.LogEntry(qText);
        questionnare.LogEntry(aText);
    }

    public void FinishSubmit()
    {
        Submit();
        FlowController.instance.NextFlowState();
    }
}
