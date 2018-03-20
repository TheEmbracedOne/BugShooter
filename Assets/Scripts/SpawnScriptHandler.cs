using UnityEngine;
using System.Collections;

public class SpawnScriptHandler : MonoBehaviour {

	public Transform[] enemyArray;
	public GameObject[] spawnPointArray;
    public string dataFileName;

	public SpawnScript spawnXml;
    private string path;
	private float elapsedTime;
    private int nodeCounter;

	void Start()
	{
        if(dataFileName.EndsWith(".xml"))
        {
            path = Application.dataPath + "/" + dataFileName;
            spawnXml = SpawnScript.Load(path);
        }
		elapsedTime = 0.0f;
        nodeCounter = 0;
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (spawnXml.nodes.ToArray().Length > nodeCounter)
        {
			if (elapsedTime > spawnXml.nodes[nodeCounter].time)
            {
                //Debug.Log(nodeCounter);
                //Debug.Log(spawnXml.nodes.ToArray().Length);
				foreach(SpawnScriptNode.Spawn spawn in spawnXml.nodes.ToArray()[nodeCounter].spawns)
                {
                    EnemySpawner.spawn(enemyArray[spawn.enemy],spawnPointArray[spawn.spawnPoint].transform.position);
				}
                elapsedTime = 0.0f;
                nodeCounter++;
            }
        }
	}

}
