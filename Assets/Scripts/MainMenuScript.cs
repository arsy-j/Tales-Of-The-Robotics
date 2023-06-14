using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public string FirstLevel;
   public string Credits;
   public string MainMenu;
   public void startGame()
   {
    SceneManager.LoadScene(FirstLevel);
    PlayerPrefs.DeleteAll();
   }

   public void creditScene()
   {
    SceneManager.LoadScene(Credits);
   }

   public void quitGame()
   {
    Application.Quit();
    Debug.Log("Game is exiting");
   }

   public void MainMenuScreen()
   {
      SceneManager.LoadScene(MainMenu);
   }
}
