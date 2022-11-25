using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;




public class OptionsRules : MonoBehaviour
{
    public GameObject teamPanel;
    public GameObject devPanel;
    public GameObject opsPanel;
    public TextMeshProUGUI DevInstructions;
            int count = 0;

    
    public void OpenPanel(GameObject panel)
    {
        teamPanel.SetActive(false);
        devPanel.SetActive(false);
        opsPanel.SetActive(false);
        
        panel.SetActive(true);

    }

   public void  GoToMenu()
   {
        SceneManager.LoadScene("MainMenuScene");
   }


    public void changeTextOps(int direction)
    {
        string[] instructions = new string[] 
        {"Existen 3 tipos de pelotas: de codigo, de bases de datos y de plataforma", 
        "Al comezar el juego se te mostrara una lista con una serie de objetivos", 
        "Deberas de cumplir los objetivos antes de que se termine el tiempo",
        "Puedes dar instrucciones a tus compañeros para que te ayuden a cumplir los objetivos",
        };
        
        if(count < instructions.Length - 1 && direction == 1)
        {
            count++;
            DevInstructions.text = instructions[count];
        }
        else if(count > 0  && direction == 0)
        {
            count--;
            DevInstructions.text = instructions[count];
        }
    }

}
