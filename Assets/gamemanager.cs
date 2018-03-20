using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour {

    private int score = 0;
    public Text gameover;
    public Text scoreboard;
    public Text time;
    bool easyClear = false;
    bool mediumClear = false;
    bool hardClear = false;
    bool legendaryClear = false;
    public GameObject orangePlanet;
    public GameObject bluePlanet;
    int repeatCount = 0;
    int lastPlanet = 0;
    int random = 0;
    bool playerDead = false;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnPlanet", 0.01f, 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!playerDead)
        {

            time.text = "Time: " + Mathf.RoundToInt(Time.timeSinceLevelLoad) + "s";

            if (Time.timeSinceLevelLoad > 80 && !legendaryClear)
            {
                CancelInvoke();
                InvokeRepeating("SpawnPlanet", 0.01f, 1f);
                legendaryClear = true;
            }

            else if (Time.timeSinceLevelLoad > 60 && !hardClear)
            {
                CancelInvoke();
                InvokeRepeating("SpawnPlanet", 0.01f, 1.3f);
                hardClear = true;
            }

            else if (Time.timeSinceLevelLoad > 40 && !mediumClear)
            {
                CancelInvoke();
                InvokeRepeating("SpawnPlanet", 0.01f, 1.5f);
                mediumClear = true;
            }

            else if (Time.timeSinceLevelLoad > 20 && !easyClear)
            {
                CancelInvoke();
                InvokeRepeating("SpawnPlanet", 0.01f, 1.7f);
                easyClear = true;
            }
        }
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreboard.text = "Score: " + score;
    }

    void SpawnPlanet()
    {
        lastPlanet = random;
        random = Random.Range(1, 3);

        if (lastPlanet == random)
        {
            ++repeatCount;
        }

        else
        {
            repeatCount = 0;
        }

        if (random == 1 && repeatCount <= 3 || random == 2 && repeatCount > 3)
        {
            Instantiate(orangePlanet, new Vector3(Random.Range(-2.7f, 2.7f), 7, 0), Quaternion.identity);
        }

        else if (random == 2 && repeatCount <= 3 || random == 1 && repeatCount > 3)
        {
            Instantiate(bluePlanet, new Vector3(Random.Range(-2.7f, 2.7f), 7, 0), Quaternion.identity);
        }
    }

    public void PlayerDead()
    {
        playerDead = true;
        gameover.gameObject.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Level");
    }
}
