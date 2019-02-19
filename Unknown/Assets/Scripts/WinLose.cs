using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public Button restartButton;
    public Button MainMenuButton;
    public Button quitGameButton;
    public string mainMenuSceneName;
    public string newGameSceneName;
    public GameObject[] lose;
    public GameObject[] win;
    public GameObject[] health;
    public bool freeze;
    public bool lockCursor;


    public void SetCursorLock(bool value) {
      lockCursor = value;
      if(lockCursor = true)
      {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      }
    }


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

    public void ExitGame() {
      Application.Quit();
    }
    //controls the pausing of the scene
    public void pauseControl(){
        if(Time.timeScale == 1)
        {
          Time.timeScale = 0;
          showWin();
        } else if (Time.timeScale == 0){
          Time.timeScale = 1;
          hideWin();
        }
    }

    //shows objects with Win tag
    public void showWin(){
      foreach(GameObject g in lose){
        g.SetActive(true);
      }
      foreach(GameObject g in win){
        g.SetActive(false);
      }
    }

    //hides objects with Win tag
    public void hideWin(){
      foreach(GameObject g in lose){
        g.SetActive(false);
        // Pauses game when Game Over screen triggered
        freeze = true;
        // Hides heart when Game Over screen triggered
        foreach(GameObject h in health){
          h.SetActive(false);
        }
      }
      foreach(GameObject g in win){
        g.SetActive(true);
        // Pauses game when Win screen triggered
        freeze = true;
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      lose = GameObject.FindGameObjectsWithTag("Lose");
      win = GameObject.FindGameObjectsWithTag("Win");
      health = GameObject.FindGameObjectsWithTag("Health");
      hideWin();
      Awake();
    }

    // Update is called once per frame
    void Update()
    {
      if (freeze == true) {
        if(Time.timeScale == 1)
        {
          Time.timeScale = 0;

          SetCursorLock(true);
        }
      }
    }
}
