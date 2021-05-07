using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private SimplePlayerScript player;
    private CollisionHandling won;
    private LevelCounter levcount;
    public GameObject LowLev;
    public GameObject HighLev;
    public GameObject winObj;
    private LineDraw ln;
    private void Start()
    {
        ln = GameObject.Find("LineDraw").GetComponent<LineDraw>();
        if (winObj.activeSelf)
        {
            winObj.SetActive(false);
        }
        player = GameObject.Find("Player").GetComponent<SimplePlayerScript>();
        won = GameObject.Find("Player").GetComponent<CollisionHandling>();
        levcount = GameObject.Find("Levelcount").GetComponent<LevelCounter>();
        Time.timeScale = 1;
        LevelDemand();
    }

    private void Update()
    {
        if (player.hasDied && !won.HasWonLevel)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void RestartWithDelay(float delay)
    {
        StartCoroutine(Delay(delay));
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Restart();
    }
    public void PlayScene()
    {
        PlayerPrefs.SetInt("Level", 1);
        StartCoroutine(delayScene("SampleScene"));
    }
    public void Options()
    {
        Debug.Log("options");
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator delayScene(string scenename)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void LevelDemand()
    {
        if (levcount.levelcounter <= 10)
        {
            if (!LowLev.activeSelf)
            {
                LowLev.SetActive(true);
            }
            if (HighLev.activeSelf)
            {
                HighLev.SetActive(false);
            }
        }
        if (levcount.levelcounter > 10)
        {
            if (LowLev.activeSelf)
            {
                LowLev.SetActive(false);
            }
            if (!HighLev.activeSelf)
            {
                HighLev.SetActive(true);
            }
        }
    }

    public void NormalLine()
    {
        ln.index = 0;
    }

    public void FastLine()
    {
        ln.index = 1;
    }

    public void BouncyLine()
    {
        ln.index = 2;
    }
}
