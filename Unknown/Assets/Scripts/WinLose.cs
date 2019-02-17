﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    //public Camera playerCam;
    //public Camera menuCam;
    public Button restartButton;
    public Button MainMenuButton;
    public Button quitGameButton;
    public string mainMenuSceneName;
    public string newGameSceneName;
    public GameObject[] lose;
    public GameObject[] win;


    public void Awake(){
      MainMenuButton.onClick.AddListener(goMainMenu);
      restartButton.onClick.AddListener(goNewGame);
      quitGameButton.onClick.AddListener(ExitGame);
    }

    public void goNewGame () {
      SceneManager.LoadScene(newGameSceneName);
    }

    public void goMainMenu () {
      SceneManager.LoadScene(mainMenuSceneName);
    }

    public void Resume() {
        Time.timeScale = 1;
        hidePaused();
    }

    public void ExitGame() {
      Application.Quit();
    }
    //controls the pausing of the scene
    public void pauseControl(){
        if(Time.timeScale == 1)
        {
          Time.timeScale = 0;
          showPaused();
        } else if (Time.timeScale == 0){
          Time.timeScale = 1;
          hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused(){
      foreach(GameObject g in lose){
        g.SetActive(true);
      }
      foreach(GameObject g in win){
        g.SetActive(false);
      }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
      foreach(GameObject g in lose){
        g.SetActive(false);
      }
      foreach(GameObject g in win){
        g.SetActive(true);
      }
    }



    // Start is called before the first frame update
    void Start()
    {
      //playerCam.enabled = true;
      //menuCam.enabled = false;
      Time.timeScale = 1;
      lose = GameObject.FindGameObjectsWithTag("Lose");
      win = GameObject.FindGameObjectsWithTag("Win");
      hidePaused();
      Awake();

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.P))
      {
        if(Time.timeScale == 1)
        {
          //menuCam.enabled = !menuCam.enabled;
          //playerCam.enabled = !playerCam.enabled;
          Time.timeScale = 0;
          showPaused();
        } else if (Time.timeScale == 0){
          //menuCam.enabled = !menuCam.enabled;
          //playerCam.enabled = !playerCam.enabled;
          Debug.Log ("high");
          Time.timeScale = 1;
          hidePaused();
        }
      }
    }
}
