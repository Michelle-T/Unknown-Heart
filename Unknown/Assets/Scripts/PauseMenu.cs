using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu
 : MonoBehaviour
{

    public Button resumeButton;
    public Button restartButton;
    public Button MainMenuButton;
    public Button quitGameButton;
    public string resumeSceneName;
    public GameObject[] pauseObjects;


    public GameObject loadGameMenu;

    public void Awake(){
      resumeButton.onClick.AddListener(Resume);
      MainMenuButton.onClick.AddListener(OpenLoadGameMenu);
      quitGameButton.onClick.AddListener(ExitGame);
    }

    public void Resume() {
        SceneManager.LoadScene(resumeSceneName);
    }

    public void OpenLoadGameMenu() {
      loadGameMenu.SetActive(true);
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
    }

    //hides objects with ShowOnPause tag
    public void hidePaused(){
      foreach(GameObject g in pauseObjects){
        g.SetActive(false);
      }
    }



    // Start is called before the first frame update
    void Start()
    {

      Time.timeScale = 1;
      pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
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
        } else if (Time.timeScale == 0){
          Debug.Log ("high");
          Time.timeScale = 1;
          hidePaused();
        }
      }
    }
}
