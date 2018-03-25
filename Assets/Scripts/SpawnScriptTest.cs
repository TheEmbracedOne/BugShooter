using UnityEngine;
using System.Collections;

public class SpawnScriptTest : MonoBehaviour
{

    public Transform[] enemyArray;
    public GameObject[] spawnPointArray;
    public string dataFileName;

    public int maxDifficultyLevel;
    public int currentLevel;

    public SpawnScript spawnXml;
    private string path;
    private float elapsedTime;
    private int nodeCounter;

    private int previousBounty;
    public bool bountyBased;

    void Start()
    {
        currentLevel = 1;
        if (dataFileName.EndsWith(".xml"))
        {
            path = Application.dataPath + "/" + dataFileName;
            spawnXml = SpawnScript.Load(path);
        }
        elapsedTime = 0.0f;
        nodeCounter = 0;
        previousBounty = GameObject.FindGameObjectWithTag("Player").GetComponent<BountyScore>().currentBounty;

    }

    void Update()
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
                    //Debug.Log(spawn.enemy + " at " + spawn.spawnPoint);
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

    private int CalculateLevel()
    {
        if (bountyBased == false)
        {
            return currentLevel;
        }

        int cBounty = GameObject.FindGameObjectWithTag("Player").GetComponent<BountyScore>().currentBounty;
        //float cTime = spawnXml.nodes[nodeCounter].time;
        int bountyDifference = cBounty - previousBounty; //pl. 20 - 17 = +3 bounty
        previousBounty = cBounty;

        //calculate dynamic difficulty quotient
        //return (int)(bountyDifference / cTime);

        //VeryHighSkill, max difficulty
        if (bountyDifference > 50)
        {
            return maxDifficultyLevel;
        }
        //HighSkill, +1 difficulty
        if (bountyDifference > 20)
        {
            if (currentLevel < maxDifficultyLevel) //need to ensure it does not exceed max difficulty
            {
                return (currentLevel + 1);
            }
        }
        //NormalSkill, same difficulty
        if (bountyDifference > 0)
        {   //between 0 and 20
            return currentLevel;
        }
        //LowSkill, -1 difficulty
        if (currentLevel > 0)
        {
            return currentLevel - 1;  //need to ensure it does not go lower than min difficulty
        }
        return currentLevel;
    }
}
