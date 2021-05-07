using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    private SimplePlayerScript countdown;
    public TextMeshProUGUI tm;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        if (!obj.activeSelf)
        {
            obj.SetActive(true);
        }
        countdown = GameObject.Find("Player").GetComponent<SimplePlayerScript>();
        int aux = (int)countdown.seconds;
        tm.text = aux.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int temp = (int)countdown.seconds;
        tm.text = temp.ToString();
        if (temp <=0)
        {
            obj.SetActive(false);
        }
        if (temp <= 6)
        {
            tm.faceColor = Color.yellow;
        }
        if (temp <= 3)
        {
            tm.faceColor = Color.red;
        }
    }
}
