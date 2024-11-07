using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject pausePlay;

    public GameObject continueButton;
    public GameObject buttonExit;

    public bool isPaused;

    public void onPauseClick(){
        if(!isPaused){
            Time.timeScale = 0;
            pausePlay.SetActive(false);
            continueButton.SetActive(true);
            buttonExit.SetActive(true);
            isPaused = true;
        }else{
            Time.timeScale = 1;
            pausePlay.SetActive(true);
            continueButton.SetActive(false);
            buttonExit.SetActive(false);
            isPaused = false;
        }
    }

    public void Continue(){
        Time.timeScale = 1;
        pausePlay.SetActive(true);
        continueButton.SetActive(false);
        buttonExit.SetActive(false);
        isPaused = false;
    }

    public void Exit(){
        Application.Quit();
    }
}
