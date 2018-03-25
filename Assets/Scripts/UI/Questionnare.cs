using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Questionnare : MonoBehaviour {

    public string QuestionnareName;
    public bool isQuestionnareFilled;

    private StreamWriter qWriter;

    void Start()
    {
        string qFile = Application.dataPath + "/" + QuestionnareName;
        isQuestionnareFilled = File.Exists(qFile);
        if (isQuestionnareFilled) return;
        qWriter = new StreamWriter(qFile, false, System.Text.Encoding.UTF8);
        qWriter.WriteLine(FileDump.instance.GetPlayerID());
    }

	public void LogEntry(string entry)
    {
        if (isQuestionnareFilled || qWriter == default(StreamWriter)) return;
        qWriter.WriteLine(entry);
    }

    void OnDisable()
    {
        if (qWriter == default(StreamWriter)) return;
        qWriter.Dispose();
        qWriter.Close();
    }
}
