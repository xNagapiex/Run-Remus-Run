using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject beforeGame;
    gamemanager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PopUp()
    {
        menu.SetActive(false);
        beforeGame.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
        gm.phoneCamOn = false;
    }

    public void PlayWithCamera()
    {
        SceneManager.LoadScene("Level");
        gm.phoneCamOn = true;
    }

    public void HiScore()
    {
        //insert the show hi-score-system here
    }
}
