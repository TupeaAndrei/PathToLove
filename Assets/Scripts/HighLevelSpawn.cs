using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLevelSpawn : MonoBehaviour
{
    public GameObject[] leveltemplates;
    private LevelCounter lev;
    // Start is called before the first frame update
    void Start()
    {
        lev = GameObject.Find("Levelcount").GetComponent<LevelCounter>();
        if (lev.levelcounter < 25)
        {
            NormalSpawn();
        }
        else
        {
            //for now
            NormalSpawn();
        }
    }

    void NormalSpawn()
    {
        int randomize = Random.Range(0, leveltemplates.Length);
        Instantiate(leveltemplates[randomize], transform.position, Quaternion.identity);
    }
}
