using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowLevelSpawner : MonoBehaviour
{
    //this willl go until level 10!
    [SerializeField] private int level;
    public Transform[] positions;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        if (level <= 5)
        {
            SpawnTilLevel5();
        }
        if (level > 5 && level <=10)
        {
            SpawnTilLevel10();
        }
    }

    public void SpawnTilLevel5()
    {
        int randompos = Random.Range(0, positions.Length);
        Instantiate(enemy, positions[randompos].position, Quaternion.identity);
    }

    public void SpawnTilLevel10()
    {
        int randompos1 = Random.Range(0, positions.Length);
        Instantiate(enemy, positions[randompos1].position, Quaternion.identity);
        int randompos2 = Random.Range(0, positions.Length);
        while (randompos2 == randompos1)
        {
            randompos2 = Random.Range(0, positions.Length);
        }
        Instantiate(enemy, positions[randompos2].position, Quaternion.identity);
    }
}
