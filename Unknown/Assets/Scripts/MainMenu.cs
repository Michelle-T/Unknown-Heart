using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button quitGameButton;
    public string newGameSceneName;
    public bool isPlay;
    public bool isQuit;


    public void NewGame() {
        SceneManager.LoadScene(newGameSceneName);
    }

    public void QuitGame() {
      Application.Quit();
    }

    public void clickListener(){
      newGameButton.onClick.AddListener(NewGame);
      quitGameButton.onClick.AddListener(QuitGame);
    }

    void OnMouseUp(){
  	if (isQuit)
  	{
  		Application.Quit();
  	}
    if(isPlay)
  	{
  		NewGame();
  	}
  }

    // Start is called before the first frame update
    void Start()
    {
      isPlay = false;
      isQuit = false;

      clickListener();
      OnMouseUp();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
