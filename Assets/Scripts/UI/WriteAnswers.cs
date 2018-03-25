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
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Submit);
        qText = this.GetComponentInParent<Question>().QuestionText;
    }

    void Update()
    {
        aText = AnswerText.text;
    }

    void Submit()
    {
        questionnare.LogEntry(qText);
        questionnare.LogEntry(aText);
    }
}
