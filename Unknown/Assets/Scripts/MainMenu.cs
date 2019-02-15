using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button newGameButton;
//    public Button loadButton;
    public Button quitGameButton;
    public string newGameSceneName;

//    public GameObject loadGame;

    public bool isPlay;
    public bool isQuit;


    public void NewGame() {
        SceneManager.LoadScene(newGameSceneName);
    }

/*    public void OpenloadGame() {
      Debug.Log("what is thisssss");
      loadGame.SetActive(true);
    }
*/

    public void QuitGame() {
      Application.Quit();
    }


    public void clickListener(){
      newGameButton.onClick.AddListener(NewGame);
      quitGameButton.onClick.AddListener(QuitGame);
    }



    void OnMouseUp(){
      Debug.Log("clickajnvsdkbsvclick");
  	if (isQuit)
  	{
      Debug.Log("quitttt");
  		Application.Quit();
  	}
    if(isPlay)
  	{
      Debug.Log("playyyyyyy");
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
