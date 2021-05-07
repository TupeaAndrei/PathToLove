using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandling : MonoBehaviour
{
    public float force;
    public float delay;
    public float deathdelay;
    public bool HasWonLevel;
    public GameObject wintext;
    private GameMaster gm;
    private LevelCounter lev;
    private SimplePlayerScript playerScript;

    private void Start()
    {
        gm = GameObject.Find("GamMaster").GetComponent<GameMaster>();
        lev = GameObject.Find("Levelcount").GetComponent<LevelCounter>();
        playerScript = GameObject.Find("Player").GetComponent<SimplePlayerScript>();
        HasWonLevel = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            HasWonLevel = true;
            lev.levelcounter++;
            PlayerPrefs.SetInt("Level", lev.levelcounter);
            Time.timeScale = 0.5f;
            //activate some image or text for level won
            if (!wintext.activeSelf)
            {
                wintext.SetActive(true);
            }
            //then restart the scene
            gm.RestartWithDelay(delay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerScript.hasDied = true;
            Destroy(collision.gameObject);
            //add death anim or particle effect
            //show high score
            //reset level count
            //for now we just restart
            gm.Restart();
        }
    }
}
