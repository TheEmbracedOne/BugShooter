using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System;

public class FileDump : MonoBehaviour {
    private const string idFileName = "id.txt";
    private string PlayerUniqueID;
    private StreamWriter SessionWriter;
    public static FileDump instance;
	void Start ()
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
            Debug.Log(PlayerUniqueID);

        }

	}
	
    public static void LogData(string[] s)
    {
        instance.SessionWriter.WriteLine("<Entry>");

        instance.SessionWriter.Write("<Time>");
        instance.SessionWriter.Write(DateTime.Now.ToLongTimeString());
        instance.SessionWriter.WriteLine("</Time>");
        foreach (string entry in s)
        {
            instance.SessionWriter.Write("<Data>");
            instance.SessionWriter.Write(s);
            instance.SessionWriter.WriteLine("</Data>");
        }
        instance.SessionWriter.WriteLine("</Entry>");
    }

    public static void LogData(string s)
    {
        instance.SessionWriter.WriteLine("<Entry>");

        instance.SessionWriter.Write("<Time>");
        instance.SessionWriter.Write(DateTime.Now.ToLongTimeString());
        instance.SessionWriter.WriteLine("</Time>");

        instance.SessionWriter.Write("<Data>");
        instance.SessionWriter.Write(s);
        instance.SessionWriter.WriteLine("</Data>");

        instance.SessionWriter.WriteLine("</Entry>");
    }

    private void CreateSessionFile()
    {
        string sessionFileName = Application.dataPath + "/" + PlayerUniqueID + "_" + GetSessionCount() + ".xml";
        SessionWriter = new StreamWriter(sessionFileName, false, System.Text.Encoding.UTF8);
        SessionWriter.WriteLine("<?xml version=" + '\"' + "1.0" + '\"' + " encoding=" + '\"' + "UTF-8" + '\"' + "?>");
        SessionWriter.WriteLine("<Sessions>");
    }

    public static void OpenSession()
    {
        instance.SessionWriter.WriteLine("<Session>");
        instance.SessionWriter.Write("<SessionDate>");
        instance.SessionWriter.Write(DateTime.Now.ToLongDateString());
        instance.SessionWriter.WriteLine("</SessionDate>");
        instance.SessionWriter.WriteLine("<Entries>");
    }

    public static void CloseSession()
    {
        instance.SessionWriter.WriteLine("</Entries>");
        instance.SessionWriter.WriteLine("</Session>");
    }

    private int GetSessionCount()
    {
        int SessionCounter;
        for (SessionCounter = 1; File.Exists(Application.dataPath + "/" + PlayerUniqueID + "_" + SessionCounter + ".txt"); SessionCounter++) ;
        return SessionCounter;
    }

    void OnDestroy()
    {
        SessionWriter.WriteLine("</Sessions>");
        SessionWriter.Close();
    }
}
