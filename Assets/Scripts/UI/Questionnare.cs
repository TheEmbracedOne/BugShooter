using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Questionnare : MonoBehaviour {

    public string QuestionnareName;
    public bool isQuestionnareFilled;
    private bool hasAnswer;
    private StreamWriter qWriter;

    void Start()
    {
        string qFile = Application.dataPath + "/FileDump/" + QuestionnareName + ".json";
        isQuestionnareFilled = File.Exists(qFile);
        if (isQuestionnareFilled) return;
        qWriter = new StreamWriter(qFile, false, System.Text.Encoding.ASCII);
        qWriter.WriteLine("{\"" + QuestionnareName + "\" : [");
        qWriter.WriteLine("\"" + FileDump.instance.GetPlayerID() + "\"" + ",");
    }

	public void LogEntry(string entry)
    {
        if (isQuestionnareFilled || qWriter == default(StreamWriter)) return;
        if (hasAnswer) { qWriter.WriteLine(","); }
        else
        {
            qWriter.WriteLine();
            hasAnswer = true;
        }
        qWriter.Write("\"" + entry + "\"");
    }

    void OnDisable()
    {
        if (qWriter == default(StreamWriter)) return;
        qWriter.WriteLine("]");
        qWriter.WriteLine("}");
        qWriter.Dispose();
        qWriter.Close();
    }
}
