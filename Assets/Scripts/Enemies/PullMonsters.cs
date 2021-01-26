using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullMonsters : MonoBehaviour
{
    [Header("Class reference")]
    [SerializeField] private Spawner spawner;

    [Header ("Spawner wave parameters")]
    public float minSpawnRate;
    public float maxSpawnRate;

    [SerializeField] private int queueIterator;
    [SerializeField] private bool bWaveEnded;

    public PullMonsters()
    {
        spawner = null;
        minSpawnRate = 3f;
        maxSpawnRate = 6f;
        queueIterator = 0;
        bWaveEnded = false;
    }

    private void Start()
    {
        StartSpawnCoroutine();
    }

    public void StartSpawnCoroutine()
    {
        StartCoroutine("Spawn");
    }

    public void StopSpawnCoroutine()
    {
        StopCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (spawner)
            {
                if (queueIterator < spawner.activeGO.Count)
                {
                    spawner.activeGO[queueIterator].SetActive(true);
                    queueIterator++;
                }
                else if(bWaveEnded)
                {
                    queueIterator = 0;
                }
            }

            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
        }
    }


}
