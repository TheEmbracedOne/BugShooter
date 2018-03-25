using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;


[XmlRoot("SpawnScript")]
public class SpawnScript 
{  
    [XmlArray("SpawnScriptNodes")]
	[XmlArrayItem("SpawnScriptNode")]
	public List<SpawnScriptNode> nodes = new List<SpawnScriptNode>();
    
	public static SpawnScript Load(string path)
	{
		XmlSerializer serializer = new XmlSerializer (typeof(SpawnScript));
		using(FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			return (serializer.Deserialize(stream) as SpawnScript);
		}
	}
}
