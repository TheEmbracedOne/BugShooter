using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WriteAnswers : MonoBehaviour {

    public GameObject Question;

    public void Submit()
    {
        string qFile = Application.dataPath + "/qFile.txt";
        StreamWriter questionnaireFiller = new StreamWriter(qFile, true, System.Text.Encoding.UTF8);

        foreach(Text t in Question.GetComponentsInChildren<Text>())
        {
            questionnaireFiller.WriteLine(t.text);
        }

        questionnaireFiller.Close();
    }
}
