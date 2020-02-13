using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyShipPrefab;
    [SerializeField]
    private GameObject[] Powerups;
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while(true)
        {
            Instantiate(EnemyShipPrefab, new Vector3(Random.Range(-8f, 8f), 6.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }       
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (true)
        {
            int RandomPowerup = Random.Range(0, 3);
            Instantiate(Powerups[RandomPowerup], new Vector3(Random.Range(-8f, 8f), 6.4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
    
}
