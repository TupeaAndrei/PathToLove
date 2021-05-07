using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomizeWinDialog : MonoBehaviour
{
    public TextMeshProUGUI mesage;
    // Start is called before the first frame update
    void Start()
    {
        int randomize = Random.Range(1, 5);
        SwitchMesage(randomize);
    }

    void SwitchMesage(int index)
    {
        switch(index)
        {
            case 1:
                mesage.text = "You Won Nice Job!";
                break;
            case 2:
                mesage.text = "Nice Keep it Going!";
                break;
            case 3:
                mesage.text = "You are awesome!";
                break;
            case 4:
                mesage.text = "That's gonna hurt!";
                break;
            case 5:
                mesage.text = "Circle Rocks Diamond Sucks!";
                break;

        }
    }
}
