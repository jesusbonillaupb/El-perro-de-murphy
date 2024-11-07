using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    public GameObject buttonPlay;
    public GameObject buttonExit;

    public void Play(){
        SceneManager.LoadScene("Nivel1");
    }

    public void Exit(){
        Application.Quit();
    }
}
