using UnityEngine;
using System.Collections;

public class SpawnScriptHandler : MonoBehaviour {

	public Transform[] enemyArray;
	public GameObject[] spawnPointArray;
    public string dataFileName;
    
    public int maxDifficultyLevel;
    public static int currentLevel;

	public SpawnScript spawnXml;
    private string path;
	private float elapsedTime;
    private int nodeCounter;
    private GameObject player;
    private int previousBounty;
    public bool bountyBased;
    //public int difficultyLevel;

    void Start()
	{
        player = GameObject.FindWithTag("Player");
        currentLevel = 1;
        if(dataFileName.EndsWith(".xml"))
        {
            path = Application.dataPath + "/" + dataFileName;
            spawnXml = SpawnScript.Load(path);
        }
		elapsedTime = 0.0f;
        nodeCounter = 0;
        previousBounty = player.GetComponent<BountyScore>().currentBounty;
        
    }

	void Update()
	{
        if(player != null)
        {
            elapsedTime += Time.deltaTime;
            if (spawnXml.nodes.ToArray().Length > nodeCounter)
            {
                if (elapsedTime > spawnXml.nodes[nodeCounter].time)
                {
                    currentLevel = CalculateLevel();
                    if (currentLevel < 0 || currentLevel > maxDifficultyLevel) { throw new System.IndexOutOfRangeException("The currentLevel is not in the specified range!"); }

                    foreach (SpawnScriptNode.Spawn spawn in spawnXml.nodes[nodeCounter].levels[currentLevel].spawns)
                    {
                        Debug.Log(currentLevel);
                        EnemySpawner.spawn(enemyArray[spawn.enemy], spawnPointArray[spawn.spawnPoint].transform.position);
                    }
                    elapsedTime = 0.0f;
                    nodeCounter++;
                }
            }
            else
            {
                this.GetComponent<EnemyQuery>().enabled = true;
            }
        }
	}

    

    int CalculateLevel()
    {
        if (!bountyBased) return maxDifficultyLevel / 2; //maxDifficultyLevel / 2;
        
        if(player != null)
        {
            BountyScore bscore = player.GetComponent<BountyScore>();

            int currentBounty = bscore.currentBounty;
            int difference = currentBounty - previousBounty;
            previousBounty = currentBounty;

            if (difference > 50) return maxDifficultyLevel;
            else if (difference > 20 && currentLevel < maxDifficultyLevel) return currentLevel + 1;
            else if (difference < 0 && currentLevel > 0) return currentLevel - 1;
            else return currentLevel;
        }
        else
        {
            return 0;
        }
        
    }
}
