using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class StaticClass 
{
     public static int CrossSceneDificulty { get; set; }
}
public class OptionsMainMenu : MonoBehaviour
{

     public GameObject PrincipalPanel;
     public GameObject LoginPanel;
     public GameObject NewGamePanel;
     public GameObject TeamPanel;

     public Button button;
     public Servidor servidor;

     public void OnEnable()
     {
          if (servidor.username != "")
          {
               button.interactable = true;
          }
     }


     public void OpenPanel(GameObject panel)
     {
          PrincipalPanel.SetActive(false);
          LoginPanel.SetActive(false);
          NewGamePanel.SetActive(false);
          TeamPanel.SetActive(false);

          panel.SetActive(true);

     }



     public void SaveDificulty(int dificulty)
     {
     }

     public void  GoToStadistics()
     {
          SceneManager.LoadScene("StatisticsScene");
     }

     public void  GoToRules()
     {
          SceneManager.LoadScene("RulesScene");
     }


          

     public void  GoToGame(int dificulty)
     {
          
          StaticClass.CrossSceneDificulty = dificulty;
          SceneManager.LoadScene("GameScene");
     }


     public void ExitGame()
     {
          Application.Quit();
     }


     
}
