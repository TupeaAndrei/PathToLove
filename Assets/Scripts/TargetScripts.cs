using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScripts : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        int randomizeX = Random.Range(0, 14);
        int randomizeY = Random.Range(-8, -7);
        Instantiate(target, new Vector2(randomizeX, randomizeY), Quaternion.identity);
    }
}
