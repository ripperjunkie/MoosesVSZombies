using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PlayerManager player;

    public List<Transform> spawnLocation;
    public List<GameObject> inactiveGO; //List of inactive objects
    public List<GameObject> activeGO; //List of active objects

    public int[] amountObjects;

    public Quaternion initRotation;

    public Spawner()
    {
        player = null;
        spawnLocation = null;
        inactiveGO = null;
        initRotation = new Quaternion();
    }

    private void Start() =>  SpawnObjects();

    private void SpawnObjects()
    {
        for (int i = 0; i < amountObjects.Length; i++)
        {
            for (int g = 0; g < amountObjects[i]; g++)
            {
                GameObject go = Instantiate(inactiveGO[i], ChooseRandomLocation(), Quaternion.identity);
                go.transform.rotation = initRotation;
                go.SetActive(false);

                MonsterBase monster = go.GetComponent<MonsterBase>();
                if (monster)
                {
                    monster.spawner = gameObject.GetComponent<Spawner>();
                }

                TowerBase tower = go.GetComponent<TowerBase>();
                if (tower)
                {
                    if (player)
                        player.PlaceObjectList(go, i);
                }
                activeGO.Add(go);
            }
        }

    }

    public Vector3 ChooseRandomLocation()
    {
        int randLoc = Random.Range(0, spawnLocation.Count);
        if(spawnLocation[randLoc])
            return spawnLocation[randLoc].transform.position;

        return new Vector3();
    }

}
