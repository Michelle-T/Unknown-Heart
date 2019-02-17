using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu1 : MonoBehaviour
{
    public Button resumeButton;
    public Button restartButton;
    public Button MainMenuButton;
    public Button quitGameButton;
    public string mainMenuSceneName;
    public string newGameSceneName;
    public GameObject[] pauseObjects;
    public GameObject[] unpauseObjects;


    public void Awake(){
      resumeButton.onClick.AddListener(Resume);
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
      foreach(GameObject g in pauseObjects){
        g.SetActive(true);
      }
      foreach(GameObject g in unpauseObjects){
        g.SetActive(false);
      }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
      foreach(GameObject g in pauseObjects){
        g.SetActive(false);
      }
      foreach(GameObject g in unpauseObjects){
        g.SetActive(true);
      }
    }


    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
      unpauseObjects = GameObject.FindGameObjectsWithTag("HideOnPause");
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

          Time.timeScale = 0;
          showPaused();
        }
        else if (Time.timeScale == 0){
          Time.timeScale = 1;
          hidePaused();
        }
      }
    }
}
