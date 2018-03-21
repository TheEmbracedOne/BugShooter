using UnityEngine;
using System.Collections;

public class SpawnScriptHandler : MonoBehaviour {

	public Transform[] enemyArray;
	public GameObject[] spawnPointArray;
    public string dataFileName;

    public int staticDifficultyLevel;
    public int maxDifficultyLevel;

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
                int currentLevel = CalculateLevel();
                if (currentLevel < 0 || currentLevel > maxDifficultyLevel) { throw new System.IndexOutOfRangeException("The currentLevel is not in the specified range!"); }
                while (spawnXml.nodes[nodeCounter].level != currentLevel) { nodeCounter++; }

				foreach(SpawnScriptNode.Spawn spawn in spawnXml.nodes.ToArray()[nodeCounter].spawns)
                {
                    EnemySpawner.spawn(enemyArray[spawn.enemy],spawnPointArray[spawn.spawnPoint].transform.position);
				}
                elapsedTime = 0.0f;
                nodeCounter+= (maxDifficultyLevel - spawnXml.nodes[nodeCounter].level);
            }
        }
	}

    private int CalculateLevel()
    {
        if (spawnXml.bountyBase == false)
        {
            return (maxDifficultyLevel / 2);
        }
        return 0;
    }
}
