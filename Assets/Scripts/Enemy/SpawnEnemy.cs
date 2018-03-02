using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    /*public GameObject obj1;
    public GameObject obj2;*/

    private float totalDistance;
    public float bountyScore;

    public Transform spawnPoint;
    public Transform enemy;

    //weighting 
    //bounty score and distance as two separate values
    //higher the bounty, the more shorter distances will be valued
    //lower the bounty, the more longer distances will be valued

    // start with x value
    // bounty 

    /* 
     * (bounty / distance) ^ N (konstans)
     * distance ^ (1 + 1 / bounty)
     * (bounty - distance) ^ N
     */

    void Start ()
    {
        /*float x = (obj1.transform.position.x - obj2.transform.position.x);
        float y = (obj1.transform.position.y - obj2.transform.position.y);
        totalDistance = Mathf.Sqrt(x * x + y * y);
        Debug.Log("Total Distance:" + totalDistance);
        Debug.Log(Mathf.Pow(totalDistance, 1 + 20 / bountyScore));*/

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("F1");
            EnemySpawner.spawn(enemy, spawnPoint.position);
        }
    }
}
