using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WriteAnswers : MonoBehaviour {

    public InputField AnswerText;
    private Questionnare questionnare;

    private string qText;
    private string aText;

    void Start()
    {
        questionnare = GetComponentInParent<Questionnare>();
        qText = this.GetComponentInParent<Question>().QuestionText;
    }

    public void Submit()
    {
        aText = AnswerText.text;
        questionnare.LogEntry(qText);
        questionnare.LogEntry(aText);
    }

    public void FinishSubmit()
    {
        Submit();
        FlowController.instance.NextFlowState();
    }
}
