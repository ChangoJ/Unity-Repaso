using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private float spawnTime, minSpawnTime, timeDecreaseStep;
    [SerializeField] private int spawnCountToDecreaseTime;
    [SerializeField] private GameObject[] prefabs;

    private int spawnCount;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomIndex], GetRandomPosition(), Quaternion.identity);
            spawnCount++;
            DecreaseSpawnTime();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void DecreaseSpawnTime()
    {
        if (spawnCount % spawnCountToDecreaseTime == 0)
        {
            spawnTime -= timeDecreaseStep;

            if(spawnTime < minSpawnTime)
            {
                spawnTime = minSpawnTime;
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        return new Vector2(transform.position.x, randomHeight);
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
}
