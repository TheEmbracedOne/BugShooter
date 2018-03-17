using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour {
    public string AnswerText;       //Answer to be filled here manually in-editor
	
    public void OnAnswerSelect()
    {
        //Dump question
        string dumpthis = this.GetComponentInParent<Question>().QuestionText;
        //Dump answer
    }
}
