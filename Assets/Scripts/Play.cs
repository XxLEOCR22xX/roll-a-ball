﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2); 
        
    }

    public void ExitGame()
    {
        // Salir del juego
        Application.Quit();
    }
}
