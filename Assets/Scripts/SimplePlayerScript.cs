using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private LevelCounter levelC;
    private LineDraw ln;
    public float seconds = 5f;
    private GameMaster gm;
    public float deathdelay;
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        levelC = GameObject.Find("Levelcount").GetComponent<LevelCounter>();
        gm = GameObject.Find("GamMaster").GetComponent<GameMaster>();
        ln = GameObject.Find("LineDraw").GetComponent<LineDraw>();
        rb2d = GetComponent<Rigidbody2D>();
        float randomize = Random.Range(-9, 0);
        transform.position = new Vector2(randomize, 7.6f);
        hasDied = false;
        SetTime(levelC.levelcounter);
    }

    private void Update()
    {
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;
        }
        if (seconds <= 0)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            ln.candraw = false;
        }

        Vector3 viewField = Camera.main.WorldToViewportPoint(transform.position);
        if (viewField.x >=0 && viewField.x <= 1 && viewField.y >= 0 && viewField.y <=1 && viewField.z > 0)
        {
            Debug.Log("In camera field");
        }
        else
        {
            hasDied = true;
            gm.RestartWithDelay(deathdelay);
        }
    }

    public void SetTime(int lev)
    {
        if (lev < 10)
        {
            seconds = 20f;
        }
        if (lev > 10 && lev < 25)
        {
            seconds = 12f;
        }
        if (lev > 25 && lev < 50)
        {
            seconds = 10f;
        }
        if (lev > 50)
        {
            seconds = 8f;
        }
    }

    public void SkipTimer()
    {
        seconds = 1.5f;
    }
}
