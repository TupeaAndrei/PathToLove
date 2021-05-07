using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    public int levelcounter=0;
    public TextMeshProUGUI lev;
    public int HighestLevel;
    void Start()
    {
        levelcounter = PlayerPrefs.GetInt("Level");
        //HighestLevel = PlayerPrefs.GetInt("HighestLevel", 1);
    }

    // Update is called once per frame
    void Update()
    { 
        lev.text = "Level:" + levelcounter.ToString();
        if (levelcounter > PlayerPrefs.GetInt("HighestLevel",levelcounter))
        {
            PlayerPrefs.SetInt("HighestLevel", levelcounter);
            HighestLevel = PlayerPrefs.GetInt("HighestLevel");
        }
    }
}
