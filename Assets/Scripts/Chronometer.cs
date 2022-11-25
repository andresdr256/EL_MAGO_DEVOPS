using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chronometer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            //Debug.Log("Dificultad"+ OptionsMainMenu.dificulty.ToString());
            Debug.Log("Dificultad "+ StaticClass.CrossSceneDificulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
