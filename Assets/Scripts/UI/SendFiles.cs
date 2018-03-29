using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Text;

public class SendFiles : MonoBehaviour
{
    private string fileToUpload;

    public void CreateAndUpload()
    {
        FileDump.CloseSessionFile();
        string[] jsonFiles = Directory.GetFiles(Application.dataPath, "*.json");
        Debug.Log("Create and upload!");
        StreamReader FileReader = new StreamReader(Application.dataPath + "/id.txt");
        FileReader.Close();
        foreach(string path in jsonFiles)
        {
            fileToUpload = path;
            StartCoroutine("Upload");
        }
    }

    public IEnumerator Upload()
    {
        StreamReader sr = new StreamReader(fileToUpload);
        string requestBody = "";
        requestBody += sr.ReadToEnd();
        sr.Close();
        requestBody = requestBody.Trim();
        UnityWebRequest www = UnityWebRequest.Post("http://46.101.5.249:8080/post",requestBody);
        www.SetRequestHeader("Content-Type", "application/json;charset=ANSI");

        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

}
