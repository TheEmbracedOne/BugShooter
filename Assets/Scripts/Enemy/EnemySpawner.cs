using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemySpawner
{

	public static void spawn(Transform enemyPrefab, Vector3 where)
    {
        GameObject.Instantiate(enemyPrefab, where, new Quaternion(), GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    public static void spawnMultiple(Transform enemyPrefab, params Vector3[] locations)
    {
        foreach(Vector3 location in locations)
        {
            EnemySpawner.spawn(enemyPrefab, location);
        }
    }
}
