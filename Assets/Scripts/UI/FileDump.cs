using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileDump : MonoBehaviour {
    public string fileName;

	void Start ()
    {
        this.GetComponent<Button>().onClick.AddListener(ButtonOnClick);
	}
	
    public void ButtonOnClick()
    {
        string filePath = Application.dataPath + "/" + fileName;
        Debug.Log("Writing to a file... Hopefully");
        StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8);
        sw.WriteLine("What is my purpose?");
        sw.WriteLine("You pass butter.");
        sw.WriteLine("Oh my god...");
        sw.WriteLine("Yeah, well, join the club, pal.");
        sw.Close();
    }

	void Update ()
    {
		
	}
}
