using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questionnare : MonoBehaviour {

    public static bool isQuestionnareFilled;

    void Awake()
    {
        string qFile = Application.dataPath + "/QuestionFile.txt";
       // isQuestionnareFilled = File.Exists(qFile);
    }

	void OnEnable()
    {

    }

    void OnDisable()
    {

    }
}
