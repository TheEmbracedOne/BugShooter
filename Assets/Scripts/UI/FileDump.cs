using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System;

public class FileDump : MonoBehaviour {
    private bool sessionOpen;
    private const string idFileName = "id.txt";
    private string PlayerUniqueID;
    private StreamWriter SessionWriter;
    public static FileDump instance;
    private string sessionFileName;

    private bool hasEntry;

    void Awake ()
    {
        if (instance == default(FileDump))
        {
            instance = this;
            string idFilePath = Application.dataPath + "/" + idFileName;
            if (!File.Exists(idFilePath))
            {
                byte[] idKey = new byte[4];
                byte[] idValue = new byte[4];
                System.Random idGen = new System.Random((int)(DateTime.Now.ToOADate() * 10000));
                StreamWriter sw = new StreamWriter(idFilePath, false, System.Text.Encoding.UTF8);
                idGen.NextBytes(idKey);
                idValue = System.Security.Cryptography.SHA256.Create().ComputeHash(idKey);
                foreach (byte b in idValue)
                {
                    sw.Write(b);
                }
                sw.Close();
            }

            StreamReader idReader = new StreamReader(idFilePath, System.Text.Encoding.UTF8);
            PlayerUniqueID = idReader.ReadLine();
            
            GetSessionCount();
            CreateSessionFile();
        }

	}

    public string GetPlayerID()
    {
        return PlayerUniqueID;
    }
	
    public static void LogData(string[] messageArray)
    {
        if (instance.hasEntry) { instance.SessionWriter.WriteLine(","); }
        else { instance.hasEntry = true; }
        instance.SessionWriter.WriteLine("{");

        instance.SessionWriter.Write("\"Time\": ");
        instance.SessionWriter.Write("\"" + DateTime.Now.ToLongTimeString() + "\"");
        instance.SessionWriter.WriteLine(",");
        int i = 1;
        foreach (string entry in messageArray)
        {
            instance.SessionWriter.Write("\"Data" + i + "\": ");
            instance.SessionWriter.Write("\"" + entry + "\"");
            if (i < messageArray.Length) instance.SessionWriter.WriteLine(",");
            else instance.SessionWriter.WriteLine();
            i++;
        }
        instance.SessionWriter.Write("}");
    }

    public static void LogData(string s)
    {
        if (instance.hasEntry) { instance.SessionWriter.WriteLine(","); }
        else { instance.hasEntry = true; }
        instance.SessionWriter.WriteLine("{");

        instance.SessionWriter.Write("\"Time\": ");
        instance.SessionWriter.Write("\"" + DateTime.Now.ToLongTimeString() + "\"");
        instance.SessionWriter.WriteLine(",");

        instance.SessionWriter.Write("\"Data1\": ");
        instance.SessionWriter.WriteLine("\"" + s + "\"");

        instance.SessionWriter.Write("}");
    }

    private void CreateSessionFile()
    {
        sessionFileName = Application.dataPath + "/" + PlayerUniqueID + "_" + GetSessionCount() + ".json";
        SessionWriter = new StreamWriter(sessionFileName, false, System.Text.Encoding.UTF8);
        
        SessionWriter.WriteLine("\"Sessions\": {");
    }

    public static void OpenSession(string isStaticLevel)
    {
        instance.sessionOpen = true;
        if (instance == null)
        {
            throw new System.NotSupportedException("No FileDump instance!");
        }
        if(instance.SessionWriter == null)
        {
            throw new System.NotSupportedException("No SessionWriter in FileDump!");
        }
        instance.SessionWriter.WriteLine("\"Session\": {");
        instance.SessionWriter.WriteLine("\"SessionData\": {");
        instance.SessionWriter.Write("\"SessionDate\": ");
        instance.SessionWriter.Write("\"" + DateTime.Now.ToLongDateString() + "\"");
        instance.SessionWriter.WriteLine(",");
        instance.SessionWriter.Write("\"SessionStaticPlay\": ");
        instance.SessionWriter.Write("\"" + isStaticLevel.ToString() + "\"");
        instance.SessionWriter.WriteLine(",");
        instance.SessionWriter.WriteLine("},");
        instance.SessionWriter.WriteLine("\"Entries\": {");
        instance.SessionWriter.WriteLine("\"Entry\": [");
        instance.hasEntry = false;
    }

    public static void CloseSession()
    {
        if (instance.hasEntry) { instance.SessionWriter.WriteLine(); }
        instance.sessionOpen = false;
        instance.SessionWriter.WriteLine("]");
        instance.SessionWriter.WriteLine("}");
        instance.SessionWriter.WriteLine("}");
    }

    private int GetSessionCount()
    {
        int SessionCounter;
        for (SessionCounter = 1; File.Exists(Application.dataPath + "/" + PlayerUniqueID + "_" + SessionCounter + ".json"); SessionCounter++) ;
        return SessionCounter;
    }

    public static void CloseSessionFile()
    {
        if (instance.sessionOpen) { CloseSession(); }
        instance.SessionWriter.WriteLine("}");
        instance.SessionWriter.Dispose();
        instance.SessionWriter.Close();
    }
}
