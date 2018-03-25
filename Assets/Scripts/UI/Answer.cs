using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour {
    public string AnswerText;       //Answer to be filled here manually in-editor

    private string question;

    public void Start()
    {
        question = GetComponentInParent<Question>().QuestionText;
        Button b = this.GetComponent<Button>();
        b.onClick.AddListener(OnAnswerSelect);
    }

    void OnAnswerSelect()
    {
        //Dump question
        GetComponentInParent<Questionnare>().LogEntry(question);
        //Dump answer
        GetComponentInParent<Questionnare>().LogEntry(AnswerText);
    }
}
