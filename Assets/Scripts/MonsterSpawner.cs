using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> Monster;
    public List<GameObject> SpawnPoints;

    
    private void Start()
    {
        StartCoroutine(SpawnHellephant());
        StartCoroutine(SpawnZomBear());
        StartCoroutine(SpawnZombunny());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnHellephant()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            Instantiate(Monster[0], SpawnPoints[0].transform.position, Quaternion.identity);
        }
    }
    private IEnumerator SpawnZomBear()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);

            Instantiate(Monster[1], SpawnPoints[1].transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnZombunny()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Instantiate(Monster[2], SpawnPoints[2].transform.position, Quaternion.identity);
        }
    }
}
