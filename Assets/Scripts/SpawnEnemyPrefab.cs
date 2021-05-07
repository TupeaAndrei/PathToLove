using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPrefab : MonoBehaviour
{
    public GameObject[] enemyprefabs;
    void Start()
    {
        int randomize = Random.Range(0, enemyprefabs.Length);
        Instantiate(enemyprefabs[randomize], transform.position, Quaternion.identity);
    }


}
