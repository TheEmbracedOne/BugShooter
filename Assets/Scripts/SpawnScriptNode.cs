using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class SpawnScriptNode
{
	[XmlElement("Time")]
	public float time;

	[XmlArray("Levels")]
    [XmlArrayItem("Level")]
	public List<Level> levels;
    
    [XmlRoot("Levels")]
    public partial class Level
    {
        [XmlArray("Spawns")]
        [XmlArrayItem("Spawn")]
        public List<Spawn> spawns = new List<Spawn>();
    }

    [XmlRoot("Spawns")]
    public partial class Spawn
    {
        [XmlElement("Enemy")]
        public int enemy;

        [XmlElement("SpawnLocation")]
        public int spawnPoint;
    }
}
